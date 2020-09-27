using NUnitLite;

namespace ApiTestingProject
{
    public static class Program
    {
        /// <summary>
        /// The main program executes the tests. Output may be routed to
        /// various locations, depending on the arguments passed.
        /// </summary>
        /// <remarks>Run with --help for a full list of arguments supported</remarks>
        /// <param name="args"></param>
        public static int Main(string[] args)
        {
            return new AutoRun().Execute(args);
        }
    }
}
