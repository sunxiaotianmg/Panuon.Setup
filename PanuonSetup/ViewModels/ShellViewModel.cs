using PanuonSetup.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanuonSetup.ViewModels
{
    [Export(typeof(IViewModel))]
    public class ShellViewModel : ViewModelBase
    {
    }
}
