using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ptc.Example.Workflow
{
    public class FlowActivity
    {

        public Sequence workflow { get; private set; }

        public FlowActivity()
        {



        }

        public Boolean Start(ILog data)
        {

            Variable<ILog> log = new Variable<ILog>("log", data);


            this.workflow = new Sequence
            {

                Activities =  {

                    new Caller(){

                        BookmarkName = "Caller"
                    },
                    new NewOpen(){

                        BookmarkName = "NewOpen"

                    },


                }

            };

            WorkflowApplication wfApp = new WorkflowApplication(workflow);

            AutoResetEvent idleEvent = new AutoResetEvent(false);

            wfApp.Idle = (WorkflowApplicationIdleEventArgs e) => { idleEvent.Set(); };

            wfApp.Run();

            BookmarkResumptionResult result = wfApp.ResumeBookmark("NewOpen", data);

            idleEvent.WaitOne();

            return result == BookmarkResumptionResult.Success;
        }

    }
}
