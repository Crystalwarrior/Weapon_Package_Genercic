addDamageType("GenericColt", '', '%2 <bitmap:base/client/ui/ci/generic> %1', 0.2, 1);
addDamageType("GenericColtCrit", '', '%2 <bitmap:base/client/ui/ci/skull> <bitmap:base/client/ui/ci/generic> %1', 0.2, 1);

datablock AudioProfile(GenericColtFire1Sound)
{
	filename    = "./res/sounds/revolver/revolver_fire01.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(GenericColtFire2Sound)
{
	filename    = "./res/sounds/revolver/revolver_fire02.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(GenericColtFire3Sound)
{
	filename    = "./res/sounds/revolver/revolver_fire03.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(GenericColtReloadSound)
{
	filename    = "./res/sounds/pistol/pistol_reload.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(GenericColtActivateSound)
{
	filename    = "./res/sounds/pistol/pistol_activate.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock ItemData(GenericRevolverColtItem)
{
	category = "Weapon";
	className = "Weapon";

	shapeFile = "./res/shapes/i_revolver_colt.dts";
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	uiName = "Revolver - Colt";
	image = GenericRevolverColtImage;
	canDrop = true;

	maxmag = 6;
	ammotype = "big boleet";
	reload = true;
};

datablock ShapeBaseImageData(GenericRevolverColtImage)
{
	shapeFile = "./res/shapes/w_revolver_colt.dts";
	emap = true;

	mountPoint = 0;
	offset = "0 0 0";
	eyeOffset = "0.7 1.2 -0.5";
	rotation = eulerToMatrix( "0 0 0" );

	correctMuzzleVector = true;
	className = "WeaponImage";

	item = GenericRevolverColtItem;

	raycastEnabled = 1;
	raycastRange = 200;
	raycastHitExplosion = GenericProjectile;
	raycastHitPlayerExplosion = GenericPlayerImpactProjectile;

	directDamage = 30;
	// directDamageType = ...;

	raycastSpread = 1.5;
	raycastCount = 1;

	raycastTracer = GenericTracerShapeData;
	raycastTracerTime = 64;
	raycastTracerSize = 0.5;
	raycastTracerColor = "0.9 0.5 0.1 1";

	casing = GenericPistolShellDebris;
	shellExitDir        = "0.5 -1.3 0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 15.0;   
	shellVelocity       = 7.0;

	melee = false;
	armReady = true;

	stateName[0]                     = "Activate";
	stateSequence[0]			    	= "Activate";
	stateTimeoutValue[0]             = 0.35;
	stateTransitionOnTimeout[0]      = "AmmoCheck";

	stateName[1]                     = "Ready";
	stateTransitionOnTriggerDown[1]  = "Fire";
	stateTransitionOnNoAmmo[1]       = "Empty";
	stateAllowImageChange[1]         = true;
	stateSequence[1]                 = "root";

	stateName[2]                     = "Fire";
	stateTransitionOnTriggerUp[2]    = "Delay";
	stateTimeoutValue[2]             = 0.18;
	stateFire[2]                     = true;
	stateAllowImageChange[2]         = false;
	stateSequence[2]                 = "Fire";
	stateScript[2]                   = "onFire";
	stateWaitForTimeout[2]           = true;
	stateEmitter[2]                  = genericPistolFlashEmitter;
	stateEmitterTime[2]              = 0.05;
	stateEmitterNode[2]              = "muzzleNode";
	stateEjectShell[2]               = false;

	stateName[3]                     = "AmmoCheck";
	stateTransitionOnTimeout[3]      = "Ready";
	stateAllowImageChange[3]         = true;
	stateScript[3]                   = "onAmmoCheck";

	stateName[4]                     = "Reload";
	stateTransitionOnTimeout[4]      = "ejectShell1";
	stateTimeoutValue[4]             = 0.8;
	stateAllowImageChange[4]         = true;
	stateSequence[4]                 = "reloadStart";
	stateScript[4]                   = "onReloadStart";

	stateName[5]                     = "ReloadMid";
	stateTransitionOnTimeout[5]      = "ReloadReady";
	stateTimeoutValue[5]             = 1;
	stateAllowImageChange[5]         = true;
	stateSequence[5]                 = "reloadEnd";
	stateScript[5]                   = "onReloadMid";

	stateName[6]                     = "ReloadReady";
	stateTransitionOnTimeout[6]      = "CheckChamber";
	stateTimeoutValue[6]             = 0.5;
	stateAllowImageChange[6]         = true;
	stateSequence[6]                 = "rollChamber";
	stateScript[6]                   = "onReload";

	stateName[7]                     = "Empty";
	stateTransitionOnTriggerDown[7]  = "EmptyFire";
	stateAllowImageChange[7]         = true;
	stateScript[7]                   = "onEmpty";
	stateTransitionOnAmmo[7]         = "Reload";
	stateSequence[7]                 = "noammo";

	stateName[8]                     = "EmptyFire";
	stateTransitionOnTriggerUp[8]    = "Empty";
	stateTimeoutValue[8]             = 0.13;
	stateAllowImageChange[8]         = false;
	stateWaitForTimeout[8]           = true;
	stateSound[8]                    = GenericEmptySound;
	stateSequence[8]                 = "noammo_fire";

	stateName[9]                     = "CheckChamber";
	stateTransitionOnTimeOut[9]      = "Ready";
	stateTransitionOnNoAmmo[9]       = "Cocking";
	stateAllowImageChange[9]         = true;
 
	stateName[10]                     = "Cocking";
	stateTransitionOnTimeOut[10]      = "Ready";
	stateTimeoutValue[10]             = 0.1;
	stateAllowImageChange[10]         = true;
	stateWaitForTimeout[10]           = true;
	stateSound[10]                    = "";
	stateScript[10]                   = "onCock";

	stateName[11]                    = "Delay";
	stateTimeoutValue[11]            = 0.35;
	stateTransitionOnTimeout[11]     = "AmmoCheck";
	stateEmitter[11]                 = GenericPistolSmokeEmitter;

	stateName[12]                    = "ejectShell1";
	stateTransitionOnTimeout[12]     = "ejectShell2";
	stateEjectShell[12]              = true;

	stateName[13]                    = "ejectShell2";
	stateTransitionOnTimeout[13]     = "ejectShell3";
	stateEjectShell[13]              = true;

	stateName[14]                    = "ejectShell3";
	stateTransitionOnTimeout[14]     = "ejectShell4";
	stateEjectShell[14]              = true;

	stateName[15]                    = "ejectShell4";
	stateTransitionOnTimeout[15]     = "ejectShell5";
	stateEjectShell[15]              = true;

	stateName[16]                    = "ejectShell5";
	stateTransitionOnTimeout[16]     = "ejectShell6";
	stateEjectShell[16]              = true;

	stateName[17]                    = "ejectShell6";
	stateTransitionOnTimeout[17]     = "ReloadMid";
	stateEjectShell[17]              = true;
};

function GenericRevolverColtImage::onReloadStart( %this, %obj, %slot )
{
	%pos = %obj.getHackPosition();
	%obj.playThread(2,shiftLeft);

	%rnd = getRandom(1,3);
	%sound = GenericPistolReloadSound;
	serverPlay3d(%sound, %pos);

	genericDisplayAmmo(%this,%obj,%slot);
}

function GenericRevolverColtImage::onReloadMid( %this, %obj, %slot )
{
	%pos = %obj.getHackPosition();

	%rnd = getRandom(1,3);
	%sound = GenericPistolReloadSound;
	serverPlay3d(%sound, %pos);
	%obj.playThread(2, plant);
	//genericDisplayAmmo(%this,%obj,%slot);
}

function GenericRevolverColtImage::onAmmoCheck( %this, %obj, %slot )
{
	genericAmmoCheck(%this,%obj,%slot);
	genericDisplayAmmo(%this,%obj,%slot);
}

function GenericRevolverColtImage::onReload( %this, %obj, %slot )
{
  // %obj.playThread(2,rotCCW);
	//serverPlay3d(genericMagnumSpinSound, %obj.getHackPosition());
	genericAmmoOnReload(%this,%obj,%slot);
	genericDisplayAmmo(%this,%obj,%slot);
}

function GenericRevolverColtImage::onCock( %this, %obj, %slot )
{
	%obj.setImageAmmo(0,1);
	genericDisplayAmmo(%this,%obj,%slot);
}

function GenericRevolverColtImage::onMount( %this, %obj, %slot )
{
	 parent::onMount(%this,%obj,%slot);
	 genericDisplayAmmo(%this,%obj,%slot,0);
}
function GenericRevolverColtImage::onUnMount( %this, %obj, %slot )
{
	 parent::onUnMount(%this,%obj,%slot);
	 genericDisplayAmmo(%this,%obj,%slot,-1);
}

function GenericRevolverColtImage::onFire(%this,%obj,%slot)
{
	if(%obj.getDamagePercent() > 1.0)
	{
		return;
	}

	if($genericWeapons::ammoSystem)
	{
		%obj.toolMag[%obj.currTool] -= 1;

		if(%obj.toolMag[%obj.currTool] < 1)
		{
			%obj.toolMag[%obj.currTool] = 0;
			%obj.setImageAmmo(0,0);
		}
		genericDisplayAmmo(%this,%obj,%slot);
	}

	Parent::onFire(%this,%obj,%slot);
	%obj.playThread(2, shiftAway);
	%sound = nameToID("GenericColtFire" @ getRandom(1, 2) @ "Sound");
	serverplay3d(%sound, %obj.gethackposition());
}

function GenericRevolverColtImage::onEmpty(%this,%obj,%slot)
{
if( $genericWeapons::Ammo && %obj.toolAmmo[%this.item.ammotype] < 1 )
{
return;
}

if(%obj.toolMag[%obj.currTool] < 1)
{
serverCmdLight(%obj.client);
}
}

function GenericRevolverColtImage::onRaycastCollision(%this, %obj, %col, %pos, %normal, %vec)
{
	if( !( %col.getType() & $typeMasks::playerObjectType || %col.getType() & $typeMasks::corpseObjectType ) )
	{
		%rnd = getRandom( 1, 4 );
		serverPlay3d( GenericBulletHitSound @ %rnd, %pos );
	}
	else
	{
		%rnd = getRandom( 1, 4 );
		serverPlay3d( GenericFleshHitSound @ %rnd, %pos );
	}

	if( !(%col.getType() & $typeMasks::playerObjectType) && !(%col.getType & $TypeMasks::vehicleObjectType) )
	{
		spawnDecal(gunShotShapeData, vectorAdd(%pos, vectorScale(%normal, 0.02)), %normal, 1);
	}

	parent::onRaycastCollision( %this, %obj, %col, %pos, %normal, %vec);
}

function GenericRevolverColtImage::damage(%this, %obj, %col, %pos, %normal, %vec)
{
	%damage = 45;
	%type = $DamageType::GenericColt;

	%z = getWord(%col.getScale(), 2);

	if (getWord(%pos, 2) > getword(%col.getWorldBoxCenter(), 2) - 3.3 * %z)
	{
		%damage = 75;
		%type = $DamageType::GenericColtCrit;

		if (isObject(CritProjectile))
		{
			%col.spawnExplosion(CritProjectile, %z);

			if (isObject(%col.client))
			{
	            %col.client.play2D(CritRecieveSound);
			}
	         
			if (%obj.getType() & $TypeMasks::PlayerObjectType)
			{
				serverPlay3D(CritFireSound, %obj.getHackPosition());

				if (isObject(%obj.client))
				{
					%obj.client.play2d(CritHitSound);
				}
			}
		}
	}

	%col.damage(%obj, %pos, %damage * %obj.getSize(), %type);

	if (%this.raycastImpactImpulse)
	{
		%col.applyImpulse(%pos, vectorScale(%vec, %this.impactImpulse));
	}
	
	if (%this.raycastVerticalImpulse)
	{
		%col.applyImpulse(%pos, vectorScale("0 0 1", %this.verticalImpulse));
	}
}

datablock ShapeBaseImageData(GenericRevolverColtSightsImage : GenericRevolverColtImage)
{
	eyeOffset = "0 1.2 -0.37";
	raycastSpread = 0.3;

	stateSound[0] = genericSightsInSound;
	stateSequence[0] = "Sights";
};

function GenericRevolverColtSightsImage::onReloadStart( %this, %obj, %slot )
{
	GenericRevolverColtImage::onReloadStart( %this, %obj, %slot );
}
function GenericRevolverColtSightsImage::onAmmoCheck( %this, %obj, %slot )
{
	GenericRevolverColtImage::onAmmoCheck( %this, %obj, %slot );
}
function GenericRevolverColtSightsImage::onReload( %this, %obj, %slot )
{
	GenericRevolverColtImage::onReload( %this, %obj, %slot );
}
function GenericRevolverColtSightsImage::onCock( %this, %obj, %slot )
{
	GenericRevolverColtImage::onCock( %this, %obj, %slot );
}
function GenericRevolverColtSightsImage::onMount( %this, %obj, %slot )
{
	parent::onMount(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot,0);
	// serverPlay3D(%sound, %obj.getHackPosition());
}
function GenericRevolverColtSightsImage::onUnMount( %this, %obj, %slot )
{
	parent::onUnMount(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot,-1);
}
function GenericRevolverColtSightsImage::onEmpty(%this,%obj,%slot)
{
	GenericRevolverColtImage::onEmpty(%this,%obj,%slot);
}
function GenericRevolverColtSightsImage::onFire( %this, %obj, %slot )
{
	GenericRevolverColtImage::onFire( %this, %obj, %slot );
}
function GenericRevolverColtSightsImage::onRaycastCollision( %this, %obj, %col, %pos, %normal, %vec)
{
	GenericRevolverColtImage::onRaycastCollision( %this, %obj, %col, %pos, %normal, %vec);
}
function GenericRevolverColtSightsImage::onRaycastDamage(%this,%obj,%slot,%col,%pos,%normal,%shotVec,%crit)
{
	GenericRevolverColtImage::onRaycastDamage(%this,%obj,%slot,%col,%pos,%normal,%shotVec,%crit);
}
function GenericRevolverColtSightsImage::onEmptyFire(%this,%obj,%slot)
{
	GenericRevolverColtImage::onEmptyFire(%this,%obj,%slot);
}

function GenericRevolverColtSightsImage::damage(%this, %obj, %col, %pos, %normal, %vec)
{
	GenericRevolverColtImage::damage(%this, %obj, %col, %pos, %normal, %vec);
}

package GenericRevolverColtPackage
{
	function Armor::onTrigger(%this, %obj, %slot, %state)
	{
		Parent::onTrigger(%this, %obj, %slot, %state);
		if(%obj.getMountedImage(0) != nameToID(GenericRevolverColtImage) && %obj.getMountedImage(0) != nameToID(GenericRevolverColtSightsImage))
		{
			return;
		}
		if(%this.canJet)
		{
			return;
		}
		if(%slot == 4)
		{
			if(%state) {
				%obj.playThread(3, shiftLeft);
				%obj.mountImage(GenericRevolverColtSightsImage, 0);
			}
			else {
				// %obj.playThread(3, shiftRight);
				%obj.mountImage(GenericRevolverColtImage, 0);
			}
		}
	}
	function serverCmdUnuseTool(%this) 
	{
		if(isObject(%this.player) && %this.player.getMountedImage(0) == nameToID(GenericRevolverColtSightsImage)) {
			return;
		}
		parent::serverCmdUnuseTool(%this);
	}
};
activatePackage(GenericRevolverColtPackage);