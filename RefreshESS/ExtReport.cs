

using System;
using System.Globalization;

namespace RefreshESS
{
    public class ExtReport
    {
        public static Calendar cal = Calendar.getInstance(TimeZone.CurrentTimeZone(get;));
        public static long time = cal.getTimeInMillis();
        public synchronized static ExtentReports getReport()
        {
            ExtentReports Report = (new ExtentReports(System.getProperty("user.dir") + "/test-output/ExtentReport_" + time + ".html", true));
            Report.addSystemInfo("Host Name", "TestMachine")
               .addSystemInfo("Environment", "Automation Testing")
               .addSystemInfo("User Name", "Tester");
            Report.loadConfig(new File(System.getProperty("user.dir") + "\\extent-config.xml"));
            return Report;
        }
    }
}
