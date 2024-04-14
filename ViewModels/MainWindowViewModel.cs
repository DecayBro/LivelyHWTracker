using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivelyHWTracker.ViewModels
{
    public class MainWindowViewModel
    {
        public string CpuName { get; set; }
        public float CpuUsage { get; set; }
        public float CpuTemperature { get; set; }
        public float RamUsage { get; set; }
        public string GpuName { get; set; }
        public float GpuUsage { get; set; }
        public float GpuTemperature { get; set;}
        public int Fps { get; set; }
        public int Frametime { get; set; }
    }
}
