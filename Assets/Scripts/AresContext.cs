using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.context.api;
using Ares.Commands;
using Ares.Services;

namespace Ares
{
    public class AresContext : MVCSContext
    {
        public AresContext(MonoBehaviour view) : base(view)
        {
        }
    
        public AresContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
        }
    
        protected override void mapBindings()
        {
            injectionBinder.Bind<IGameService>().To<BasicGameService>();

            commandBinder.Bind(ContextEvent.START).To<StartCommand>();
        }
    }
}
