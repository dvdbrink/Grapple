#!/bin/bash

ln -s Submodules/MessageKit/Assets/MessageKit Assets/Plugins/MessageKit
ln -s Submodules/Procedural/Procedural Assets/Plugins/Procedural
ln -s Submodules/StateKit/Assets/StateKit Assets/Plugins/StateKit

mkdir Assets/Plugins/Zenject
ln -s Submodules/Zenject/UnityProject/Assets/Zenject/Internal Assets/Plugins/Zenject/Internal
ln -s Submodules/Zenject/UnityProject/Assets/Zenject/Main Assets/Plugins/Zenject/Main
