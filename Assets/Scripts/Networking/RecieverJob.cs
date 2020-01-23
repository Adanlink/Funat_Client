using Client.Jobs;
using System.IO;

namespace Client.Networking
{
    public class RecieverJob : ThreadedJob
    {
        public Stream NetworkStream { get; set; }

        protected override void ThreadFunction()
        {
            // Do your threaded task. DON'T use the Unity API here
            while (NetworkStream != null)
            {

            }
        }

        protected override void OnFinished()
        {
            // This is executed by the Unity main thread when the job is finished

        }
    }
}