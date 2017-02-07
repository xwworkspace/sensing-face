using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Events;

namespace SING.Infrastructure.Events
{
    public class Current_LayoutName_ChangedEvent : CompositePresentationEvent<string>
    {
    }

    public class CallForOpenDocumentEvent : CompositePresentationEvent<CallForOpenDocumentParameters>
    {
    }

    public class CallForCloseDocumentEvent : CompositePresentationEvent<CallForCloseOrActiveDocumentParameters>
    {
    }
    public class CloseCurrentAllComponentsEvent : CompositePresentationEvent<string>
    {
    }
}
