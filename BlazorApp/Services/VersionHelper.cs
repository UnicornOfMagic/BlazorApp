using BlazorApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class VersionHelper
    {
        private IList<Software> AllSoftware = new List<Software>();
        public VersionHelper()
        {
            foreach (var software in SoftwareManager.GetAllSoftware())
            {
                AllSoftware.Add(software);
            }
        }

        public IList<Software> GetSoftwareNewerThan(int major, int minor, int patch)
        {
            var queriedSoftware = new List<Software>();

            foreach (var software in AllSoftware)
            {
                int softwareMajor = 0;
                int softwareMinor = 0;
                int softwarePatch = 0;

                var versionSplit = software.Version.Split('.');

                if (versionSplit.Length >= 3)
                {
                    int.TryParse(versionSplit[2], out softwarePatch);
                }

                if (versionSplit.Length >= 2)
                {
                    int.TryParse(versionSplit[1], out softwareMinor);
                }

                if (versionSplit.Length >= 1)
                {
                    int.TryParse(versionSplit[0], out softwareMajor);
                }

                if (softwareMajor > major ||
                    softwareMajor == major && softwareMinor > minor ||
                    softwareMajor == major && softwareMinor == minor && softwarePatch > patch)
                {
                    queriedSoftware.Add(software);
                }
            }

            return queriedSoftware;
        }
    }
}
