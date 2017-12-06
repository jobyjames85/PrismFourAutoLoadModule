using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismFourAuto.Staff
{
    public class ProgressAsyncWork
    {

        public ProgressAsyncWork()
        {

        }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        //public IProgress<int> ProgressReporter
        //{
        //    get;
        //    set;
        //}

        //public async Task StartAsync()
        //{
        //    await Task.Factory.StartNew(() =>
        //    {
        //        try
        //        {
        //            int length = 100;
        //            for (int index = 0; index < length; index++)
        //            {
        //                int currentValue = Convert.ToInt32((index / (float)length) * 100);
        //                this.ProgressReporter.Report(currentValue);
        //                Thread.Sleep(1000);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    });
        //}
    }
}
