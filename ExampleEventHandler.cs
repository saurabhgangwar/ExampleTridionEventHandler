using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tridion.ContentManager.ContentManagement;
using Tridion.ContentManager.Extensibility;
using Tridion.ContentManager.Extensibility.Events;
namespace ExampleTridionEventHandler
{
    [TcmExtension("ExampleEventHandler")]
    public class ExampleEventHandler : TcmExtension
    {
        /// <summary>
        /// Constructor
        /// used to sunscribe for a event
        /// </summary>
        public ExampleEventHandler()
        {
            //call the subscribe method
            Subscribe();
        }
        /// <summary>
        /// method to subscribe save event handler for a component
        /// </summary>
        public void Subscribe()
        {
            //subscribe event handler function for component save event on intiated phase
            EventSystem.Subscribe<Component, SaveEventArgs>(HandlerForInitiated, EventPhases.Initiated);
        }
        /// <summary>
        /// HandlerForInitiated -
        /// this function is called when the save event of a component is initiated
        /// </summary>
        /// <param name="component">the component against the save event is initiated</param>
        /// <param name="args">arguments</param>
        /// <param name="phase">event phase</param>
        private void HandlerForInitiated(Component component, SaveEventArgs args, EventPhases phase)
        {
            
            //get the component title
            var comptitle = component.Title;
            //if image filename and component title are not the same, thorow error
            
            if (!Regex.IsMatch(comptitle, @"^\d+"))
            {
                throw new Exception("Component title must start with a number.");
            }
        }
    }
}