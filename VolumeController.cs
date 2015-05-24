using CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commander
{
    class VolumeController
    {
        public static void mutevol(bool fl)
        {
            new MMDeviceEnumerator().GetDefaultAudioEndpoint(
            EDataFlow.eRender, ERole.eMultimedia
            ).AudioEndpointVolume.Mute = fl;
        }
        public static void setvol(int n)
        {
            new MMDeviceEnumerator().GetDefaultAudioEndpoint(
            EDataFlow.eRender, ERole.eMultimedia
            ).AudioEndpointVolume.MasterVolumeLevelScalar = ((float)n / 100.0f);
        }
    }
}
