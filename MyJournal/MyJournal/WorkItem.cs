using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJournal
{
    class WorkItem
    {
        public WorkItem(DateTime t1, String w1) {
            this.time = t1;
            this.workItem = w1;
        }

        private String _workItem;
        public String workItem {
            get { return workItem; }
            set { _workItem = value; }
        }
        private DateTime _time;
        public DateTime time {
            get { return time; }
            set { _time = value; }
        }



    


    }
}
