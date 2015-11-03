using UnityEngine;
using strange.extensions.command.impl;

namespace Ares.Commands
{
	public class StartCommand : Command
	{
        public override void Execute()
        {
            Debug.Log("StartCommand");
        }
	}
}
