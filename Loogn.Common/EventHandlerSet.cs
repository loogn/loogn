using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Loogn.Common
{
    public class EventHandlerSet:IDisposable
    {
        Hashtable events = new Hashtable();
        public virtual Delegate this[object eventKey]
        {
            get
            {
                return (Delegate)events[eventKey];
            }
            set
            {
                events[eventKey] = value;
            }
        }

        public virtual void AddHandler(object eventKey, Delegate handler)
        {
            events[eventKey] = Delegate.Combine((Delegate)events[eventKey], handler);
        }
        public virtual void RemoveHandler(object eventKey, Delegate handler)
        {
            events[eventKey] = Delegate.Remove((Delegate)events[eventKey], handler);
        }


        public virtual void Fire(Object eventKey, object sender, EventArgs e)
        {
            Delegate d = (Delegate)events[eventKey];
            if (d != null)
            {
                d.DynamicInvoke(new object[] { sender, e });
            }
        }

        public void Dispose()
        {
            events = null;
        }

        public static EventHandlerSet Syschronized(EventHandlerSet eventHandlerSet)
        {
            if (eventHandlerSet == null)
            {
                throw new ArgumentNullException("eventHandlerSet");
            }
            return new SysnchronizedEventHandlerSet(eventHandlerSet);
        }

        private class SysnchronizedEventHandlerSet : EventHandlerSet {
            private EventHandlerSet eventHandlerSet;

            public SysnchronizedEventHandlerSet(EventHandlerSet eventHandlerSet) {
                this.eventHandlerSet = eventHandlerSet;
                Dispose();
            }

            public override Delegate this[object eventKey]
            {
                [MethodImpl( MethodImplOptions.Synchronized)]
                get
                {
                    return eventHandlerSet[eventKey];
                }
                set
                {
                    eventHandlerSet[eventKey]= value;
                }
            }

            public override void AddHandler(object eventKey, Delegate handler)
            {
                eventHandlerSet.AddHandler(eventKey, handler);
            }

            public override void RemoveHandler(object eventKey, Delegate handler)
            {
                eventHandlerSet.RemoveHandler(eventKey, handler);
            }

            public override void Fire(object eventKey, object sender, EventArgs e)
            {
                eventHandlerSet.Fire(eventKey, sender, e);
            }
        }
    }
}
