using PanuonSetup.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanuonSetup.Project.Implements
{
    [Export(typeof(IProjectManager))]
    class ProjectManagerImpl : IProjectManager
    {
        public void CreateProject(PackType projectType, string name, string sourcePath)
        {
        }
    }
}
