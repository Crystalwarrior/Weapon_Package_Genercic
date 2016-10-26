//sounds
datablock AudioProfile(GenericLizzyFire1Sound)
{
	filename    = "./res/sounds/sniper/sniper_fire01.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(GenericLizzyFire2Sound)
{
	filename    = "./res/sounds/sniper/sniper_fire02.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(GenericLizzyFire3Sound)
{
	filename    = "./res/sounds/sniper/sniper_fire03.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(GenericLizzyReloadSound)
{
	filename    = "./res/sounds/sniper/sniper_reload.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(GenericLizzyActivateSound)
{
	filename    = "./res/sounds/shared/generic_activate-03.wav";
	description = AudioClosest3d;
	preload = true;
};

addDamageType("GenericLizzy", '', '%2 <bitmap:base/client/ui/ci/generic> %1', 0.2, 1);
addDamageType("GenericLizzyCrit", '', '%2 <bitmap:base/client/ui/ci/skull> <bitmap:base/client/ui/ci/generic> %1', 0.2, 1);

datablock ItemData(GenericSniperLizzyItem)
{
	category = "Weapon";
	className = "Weapon";

	shapeFile = "./res/shapes/i_sniper_lizzy.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	uiName = "Sniper - Lizzy";
	image = GenericSniperLizzyImage;
	canDrop = true;

	maxmag = 1;
	ammotype = "Sniper Ammo";
	reload = true;
};

////////////////
//weapon image//
////////////////
datablock ShapeBaseImageData(GenericSniperLizzyImage)
{
	shapeFile = "./res/shapes/w_sniper_lizzy.dts";
	emap = true;

	mountPoint = 0;
	offset = "0 0 0";
	eyeOffset = "0.7 0.75 -0.75";
	rotation = eulerToMatrix( "0 0 0" );

	correctMuzzleVector = true;
	className = "WeaponImage";

	item = GenericSniperLizzyItem;

	raycastEnabled = 1;
	raycastRange = 200;
	raycastHitExplosion = GenericProjectile;
	raycastHitPlayerExplosion = GenericPlayerImpactProjectile;

	directDamage = 45;
	directDamageType = $DamageType::GenericLizzy;

	directCritDamage = 135;
	directCritDamageType = $DamageType::GenericLizzyCrit;

	raycastSpread = 2;
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

	// stateName[0]						= "Activate";
	// stateSequence[0]					= "Activate";
	// stateTransitionOnTimeout[0]			= "AmmoCheck";

	// stateName[1]						= "Ready";
	// stateTransitionOnNoAmmo[1]			= "Empty";
	// stateTransitionOnTriggerDown[1]		= "Fire";
	// stateAllowImageChange[1]			= true;

	// stateName[2]						= "Fire";
	// stateTransitionOnTriggerUp[2]		= "Smoke";
	// stateTimeoutValue[2]				= 0.25;
	// stateFire[2]						= true;
	// stateAllowImageChange[2]			= false;
	// stateSequence[2]					= "Fire";
	// stateScript[2]						= "onFire";
	// stateWaitForTimeout[2]				= true;
	// stateEmitter[2]						= GenericPistolFlashEmitter;
	// stateEmitterTime[2]					= 0.05;
	// stateEmitterNode[2]					= "muzzleNode";
	// stateEjectShell[2]					= true;

	// stateName[3]						= "AmmoCheck";
	// stateTransitionOnTimeout[3]			= "Ready";
	// stateAllowImageChange[3]			= 1;
	// stateScript[3]						= "onAmmoCheck";

	// stateName[4]						= "Reload";
	// stateTransitionOnTimeout[4]			= "ReloadReady";
	// stateTimeoutValue[4]				= 1.4;
	// stateAllowImageChange[4]			= false;
	// //stateScript[4]						= "onReloadStart";
	// stateScript[4]						= "onReload";
	// stateSequence[4]					= "Reload";
	// stateSound[4]						= GenericLizzyReloadSound;

	// stateName[5]						= "ReloadReady";
	// stateTransitionOnTimeout[5]			= "CheckChamber";
	// stateTimeoutValue[5]				= 0.1;
	// stateAllowImageChange[5]			= false;
	// //stateScript[5]						= "onReload";
	// stateScript[5]						= "onReloadReady";
	// stateSequence[5]					= "";

	// stateName[6]						= "Empty";
	// stateTransitionOnTriggerDown[6]		= "EmptyFire";
	// stateAllowImageChange[6]			= true;
	// tateTransitionOnAmmo[7]				= "Reload";
	// stateScript[6]						= "onEmpty";
	// stateTransitionOnAmmo[6]			= "Reload";
	// //stateSequence[6]					= "empty";

	// stateName[7]						= "EmptyFire";
	// stateTransitionOnTriggerUp[7]		= "Empty";
	// stateTimeoutValue[7]				= 0.13;
	// stateAllowImageChange[7]			= false;
	// stateWaitForTimeout[7]				= true;
	// stateSound[7]						= GenericEmptySound;
	// stateSequence[7]					= "emptyFire";
	// stateScript[7]						= "onEmptyFire";

	// stateName[8]						= "CheckChamber";
	// stateTransitionOnTimeOut[8]			= "Ready";
	// stateTransitionOnNoAmmo[8]			= "Cocking";
	// stateAllowImageChange[8]			= true;

	// stateName[9]						= "Cocking";
	// stateTransitionOnTimeOut[9]			= "Ready";
	// stateTimeoutValue[9]				= 0.1;
	// stateAllowImageChange[9]			= true;
	// stateWaitForTimeout[9]				= true;
	// stateSound[9]						= "";
	// stateScript[9]						= "onCock";

	// stateName[10]						= "Smoke";
	// stateEmitter[10]					= GenericPistolSmokeEmitter;
	// //stateTransitionOnTimeOut[10]		= "AmmoCheck";
	// stateTransitionOnTimeout[10]		= "Reload";
	// stateEmitterTime[10]				= 0.05;
	// stateEmitterNode[10]				= "muzzleNode";

	stateName[0] = "Activate";
	//stateScript[0] = "onActivate";
	stateSequence[0] = "Activate";
	stateTimeoutValue[0] = 0.4;
	//stateWaitForTimeout[0] = 0;
	//stateTransitionOnNoAmmo[0] = "CheckAmmo";
	stateTransitionOnTimeout[0] = "CheckAmmo";

	stateName[1] = "CheckAmmo";
	stateScript[1] = "onCheckAmmo";
	stateTransitionOnTimeout[1] = "Ready";

	stateName[2] = "CheckReload";
	stateScript[2] = "onCheckReload";
	stateTransitionOnTimeout[2] = "Empty";

	stateName[3] = "Empty";
	stateTimeoutValue[4] = 0.13;
	stateTransitionOnTriggerDown[3] = "EmptyFire";
	stateTransitionOnAmmo[3] = "Reload";

	stateName[4] = "EmptyFire";
	stateScript[4] = "onEmptyFire";
	stateSound[4] = GenericEmptySound;
	stateSequence[4] = "emptyFire";
	stateAllowImageChange[4] = 0;
	//stateTimeoutValue[4] = 0.13;
	stateTransitionOnTriggerUp[4] = "Empty";

	stateName[5] = "Ready";
	stateTransitionOnTriggerDown[5] = "Fire";
	stateTransitionOnNoAmmo[5] = "CheckReload";

	stateName[6] = "Fire";
	stateFire[6] = 1;
	stateScript[6] = "onFire";
	stateEmitter[6] = GenericPistolFlashEmitter;
	stateEmitterTime[6] = 0.05;
	stateEmitterNode[6] = "muzzleNode";
	stateEjectShell[6] = 1;
	stateSequence[6] = "Fire";
	stateTimeoutValue[6] = 0.25;
	stateAllowImageChange[6] = 0;
	stateTransitionOnTriggerUp[6] = "Smoke";

	stateName[7] = "Smoke";
	stateEmitter[7] = GenericPistolSmokeEmitter;
	stateEmitterTime[7] = 0.05;
	stateEmitterNode[7] = "muzzleNode";
	stateTimeoutValue[7] = 0.2;
	stateAllowImageChange[7] = 0;
	stateTransitionOnTimeout[7] = "CheckAmmo";

	stateName[8] = "Reload";
	stateScript[8] = "onReload";
	stateSound[8] = GenericLizzyReloadSound;
	stateSequence[8] = "Reload";
	stateAllowImageChange[8] = 1;
	stateTimeoutValue[8] = 1.4;
	stateTransitionOnTimeout[8] = "ReloadFinish";

	stateName[9] = "ReloadFinish";
	stateScript[9] = "onReloadFinish";
	stateAllowImageChange[9] = 0;
	// stateTimeoutValue[9] = 0.1;
	stateTransitionOnTimeout[9] = "CheckAmmo";
};

function GenericSniperLizzyImage::onMount(%this, %obj, %slot)
{
	genericDisplayAmmo(%this, %obj, %slot);
}

function GenericSniperLizzyImage::onUnMount(%this, %obj, %slot)
{
	genericDisplayAmmo(%this, %obj, %slot, -1);
}

function GenericSniperLizzyImage::onCheckAmmo(%this, %obj, %slot)
{
	%obj.setImageAmmo(%slot, 1);
	genericAmmoCheck(%this, %obj, %slot);
	genericDisplayAmmo(%this, %obj, %slot);
	//talk("::onCheckAmmo -> imageAmmo to " @ %obj.getImageAmmo(%slot));
}

function GenericSniperLizzyImage::onCheckReload(%this, %obj, %slot)
{
	%obj.setImageAmmo(%slot, %obj.toolAmmo[%this.item.ammoType] > 0);
	//talk("::onCheckReload -> imageAmmo to " @ %obj.getImageAmmo(%slot));
}

function GenericSniperLizzyImage::onReload(%this, %obj, %slot)
{
	%obj.playThread(2, "shiftRight");
	genericDisplayAmmo(%this, %obj, %slot);
}

function GenericSniperLizzyImage::onReloadFinish(%this, %obj, %slot)
{
	%obj.playThread(2, "plant");
	genericAmmoOnReload(%this, %obj, %slot);
	genericDisplayAmmo(%this, %obj, %slot);
}

function GenericSniperLizzyImage::onEmptyFire(%this, %obj, %slot)
{
	%obj.playThread(2, "plant");
	genericDisplayAmmo(%this, %obj, %slot);
}

function GenericSniperLizzyImage::onFire(%this, %obj, %slot)
{
	if (%obj.getDamagePercent() > 1.0)
	{
		return;
	}

	if($GenericWeapons::ammoSystem)
	{
		%obj.toolMag[%obj.currTool] -= 1;

		if(%obj.toolMag[%obj.currTool] < 1)
		{
			%obj.toolMag[%obj.currTool] = 0;
			%obj.setImageAmmo(0,0);
		}
		GenericDisplayAmmo(%this,%obj,%slot);
	}

	parent::onFire( %this, %obj, %slot );

	%obj.playThread(2, shiftRight);
	%obj.playThread(3, shiftLeft);
	if(%obj.getMountedImage(0) == nameToID(GenericSniperLizzyImage))
		%shake = "0.5 0.5 0.5";
	else
		%shake = "0.25 0.25 0.25";

	%obj.spawnExplosion(GenericRecoilSmallProjectile, %shake);
	serverPlay3d( "GenericLizzyFire" @ getRandom(1,2) @ "Sound", %obj.getHackPosition() );
}

function GenericSniperLizzyImage::onRaycastCollision(%this, %obj, %col, %pos, %normal, %vec)
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

function player::statedebug(%this,%prev)
{
	cancel(%this.statedebug);
	%state=%this.getimagestate(0);
	if(%state!$=%prev)talk("state:" SPC %state);
	%this.statedebug=%this.schedule(0,statedebug,%state);
}

function GenericSniperLizzyImage::damage(%this, %obj, %col, %pos, %normal, %vec)
{
	%damage = 45;
	%type = $DamageType::GenericLizzy;

	%z = getWord(%col.getScale(), 2);

	if (getWord(%pos, 2) > getword(%col.getWorldBoxCenter(), 2) - 3.3 * %z)
	{
		%damage = 150;
		%type = $DamageType::GenericLizzyCrit;

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

// Scope

datablock ShapeBaseImageData(GenericSniperLizzyScopeImage : GenericSniperLizzyImage)
{
	shapeFile = "./res/shapes/w_sniper_lizzy_scoped.dts";
	eyeOffset = "0 -0.08 -0.55";
	raycastSpread = 0;

	// Bring up scope faster
	stateScript[0] = "";
	stateTimeoutValue[0] = 0.2;
	stateWaitForTimeout[0] = "";
	stateTransitionOnNoAmmo[0] = "";

	// Unscope instead of reloading
	stateTransitionOnTimeout[2] = "ExitScope";
	stateTransitionOnAmmo[3] = "ExitScope";

	stateName[11] = "ExitScope";
	stateScript[11] = "onExitScope";
	stateAllowImageChange[11] = 1;
};

function GenericSniperLizzyScopeImage::onMount(%this, %obj, %slot)
{
	Parent::onMount(%this, %obj, %slot);

	GenericDisplayAmmo(%this, %obj, %slot, 0);
	%obj.playThread(3, shiftLeft);
}

function GenericSniperLizzyScopeImage::onUnMount(%this, %obj, %slot)
{
	Parent::onUnMount(%this, %obj, %slot);
	GenericDisplayAmmo(%this, %obj, %slot, -1);
}

function GenericSniperLizzyScopeImage::onExitScope(%this, %obj, %slot)
{
	%obj.mountImage(GenericSniperLizzyImage, %slot);
	fixArmReady(%obj);
}

function GenericSniperLizzyScopeImage::onFire(%this, %obj, %slot)
{
	GenericSniperLizzyImage::onFire(%this, %obj, %slot);
}

function GenericSniperLizzyScopeImage::onReloadFinish(%this, %obj, %slot)
{
	GenericSniperLizzyImage::onReloadFinish(%this, %obj, %slot);
}

function GenericSniperLizzyScopeImage::onCheckAmmo(%this, %obj, %slot)
{
	GenericSniperLizzyImage::onCheckAmmo(%this, %obj, %slot);
}

function GenericSniperLizzyScopeImage::onCheckReload(%this, %obj, %slot)
{
	GenericSniperLizzyImage::onCheckReload(%this, %obj, %slot);
}

function GenericSniperLizzyScopeImage::onRaycastCollision(%this, %obj, %col, %pos, %normal, %vec)
{
	GenericSniperLizzyImage::onRaycastCollision( %this, %obj, %col, %pos, %normal, %vec);
}

function GenericSniperLizzyScopeImage::damage(%this, %obj, %col, %pos, %normal, %vec)
{
	GenericSniperLizzyImage::damage(%this, %obj, %col, %pos, %normal, %vec);
}

function GenericSniperLizzyScopeImage::onEmptyFire(%this, %obj, %slot)
{
	GenericSniperLizzyImage::onEmptyFire(%this, %obj, %slot);
}

package GenericSniperLizzyPackage
{
	function Armor::onTrigger(%this, %obj, %slot, %state)
	{
		Parent::onTrigger(%this, %obj, %slot, %state);

		if (%state && %slot == 4 && !%this.canJet)
		{
			%image = %obj.getMountedImage(0);

			if (%image == nameToID("GenericSniperLizzyImage"))
			{
				%sound = "GenericSightsInSound";
				%obj.mountImage(GenericSniperLizzyScopeImage, 0);
			}
			else if (%image == nameToID("GenericSniperLizzyScopeImage"))
			{
				%sound = "GenericSightsOutSound";
				%obj.mountImage(GenericSniperLizzyImage, 0);
			}

			if (isObject(%sound))
			{
				serverPlay3D(%sound, %obj.getHackPosition());
			}
		}
	}
};

activatePackage("GenericSniperLizzyPackage");