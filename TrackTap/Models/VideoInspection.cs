using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrackTap.Models
{
    public class VideoInspection
    {
        public double StartTimeInMilliseconds { get; private set; }
        public List<MarkedPlacer> MarkedPlacers { get; private set; } = new List<MarkedPlacer>();
        public class MarkedPlacer
        {
            public string IdentifyingInformation { get; private set; }
            public double MarkedMillisecondsInVideo { get; private set; }

            public MarkedPlacer(string identifyingInformation, double markedMillisecondsInVideo)
            {
                IdentifyingInformation = identifyingInformation;
                MarkedMillisecondsInVideo = markedMillisecondsInVideo;
            }
        }

        public void SetStartingMilliseconds(double timeCrossingLineInMilliseconds)
        {
            this.StartTimeInMilliseconds = timeCrossingLineInMilliseconds;
        }

        internal void AddMarkedPlacer(string identifyingInformation, double markedMillisecondsInVideo)
        {
            this.MarkedPlacers.Add(
                new MarkedPlacer(
                    identifyingInformation: identifyingInformation,
                    markedMillisecondsInVideo: markedMillisecondsInVideo
                )
            );
        }
    }
}
