using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystem.Multimedia.MCI
{
    public class Audio : Media
    {
        public Audio(string mediaName)
        {
            base.MediaName = mediaName;
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        internal override void Open(string filePath)
        {
            String command = String.Concat("Open \"", filePath, "\" alias ", base.MediaName);

            base.ExecuteMCICommand(command);
        }
    }
}
