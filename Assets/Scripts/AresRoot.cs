using strange.extensions.context.impl;

namespace Ares
{
	public class AresRoot : ContextView
    {
        void Awake()
        {
            context = new AresContext(this);
        }
    }
}
