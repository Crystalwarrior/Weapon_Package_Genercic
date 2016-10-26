//sounds
datablock AudioProfile(GenericMossbergShotgunFireSound)
{
	filename    = "./res/sounds/shotgun/shotgun_fire.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(GenericMossbergShotgunPumpSound)
{
	filename    = "./res/sounds/shotgun/shotgun_pump.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(GenericMossbergShotgunShellSound1)
{
	filename    = "./res/sounds/shotgun/shotgun_reload01.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(GenericMossbergShotgunShellSound2)
{
	filename    = "./res/sounds/shotgun/shotgun_reload02.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(GenericMossbergShotgunShellSound3)
{
	filename    = "./res/sounds/shotgun/shotgun_reload03.wav";
	description = AudioClosest3d;
	preload = true;
};

AddDamageType("GenericMossbergShotgun",   '<bitmap:add-ons/Weapon_Pack_Generic/res/shapes/icons/CI_Shotgun> %1',    '%2 <bitmap:add-ons/Weapon_Pack_Generic/res/shapes/icons/CI_Shotgunl> %1',0.2,1);
datablock ProjectileData(GenericMossbergShotgunProjectile : GenericProjectile)
{
	directDamageType    = $DamageType::GenericMossbergShotgun;
	radiusDamageType    = $DamageType::GenericMossbergShotgun;
};

//////////
// item //
//////////
datablock ItemData(GenericMossbergShotgunItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = "./res/shapes/i_shotgun_mossberg.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "Shotgun - Mossberg (Pump)";
	//iconName = "./icons/icon_Pistol";
	doColorShift = false;
	colorShiftColor = "0.25 0.25 0.25 1.000";

	maxmag = 6;
	ammotype = "buckshot";
	reload = true;

	 // Dynamic properties defined by the scripts
	image = GenericMossbergShotgunImage;
	canDrop = true;
};

////////////////
//weapon image//
////////////////
datablock ShapeBaseImageData(GenericMossbergShotgunImage)
{
	// Basic Item properties
	shapeFile = "./res/shapes/w_shotgun_mossberg.dts";
	emap = true;

	// Specify mount point & offset for 3rd person, and eye offset
	// for first person rendering.
	mountPoint = 0;
	offset = "0 0 0";
	eyeOffset = "0.6 0.5 -0.6";
	rotation = eulerToMatrix( "0 0 0" );

	// When firing from a point offset from the eye, muzzle correction
	// will adjust the muzzle vector to point to the eye LOS point.
	// Since this weapon doesn't actually fire from the muzzle point,
	// we need to turn this off.  
	correctMuzzleVector = true;

	// Add the WeaponImage namespace as a parent, WeaponImage namespace
	// provides some hooks into the inventory system.
	className = "WeaponImage";

	// Projectile && Ammo.
	item = GenericMossbergShotgunItem;
	ammo = " ";
	projectile = GenericMossbergShotgunProjectile;
	projectileType = Projectile;


	raycastEnabled = 1;
	raycastRange = 100;
	raycastHitExplosion = GenericMossbergShotgunProjectile;
	raycastHitPlayerExplosion = GenericPlayerImpactProjectile;

	directDamage = 15; //10
	directDamageType = $DamageType::GenericMossbergShotgun;

	raycastSpread = 15; // 12
	raycastCount = 12;

	raycastTracer = GenericTracerShapeData;
	raycastTracerTime = 64;
	raycastTracerSize = 0.25;
	raycastTracerColor = "0.9 0.5 0.1 1";


	casing = GenericShotgunShellDebris;
	shellExitDir        = "0.5 -1.3 0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 15.0;   
	shellVelocity       = 7.0;

	//melee particles shoot from eye node for consistancy
	melee = false;
	//raise your arm up or not
	armReady = true;

	doColorShift = false;
	colorShiftColor = GenericPistolItem.colorShiftColor;//"0.400 0.196 0 1.000";

	//casing = " ";

	// Images have a state system which controls how the animations
	// are run, which sounds are played, script callbacks, etc. This
	// state system is downloaded to the client so that clients can
	// predict state changes and animate accordingly.  The following
	// system supports basic ready->fire->reload transitions as
	// well as a no-ammo->dryfire idle state.

	// Initial start up state
	stateName[0]                    = "Activate";
	stateTimeoutValue[0]            = 0.4;
	stateTransitionOnTimeout[0]     = "AmmoCheck";
	stateSequence[0]				= "activate";
	stateSound[0]					= GenericActivate3Sound;

	stateName[1]                    = "Ready";
	stateTransitionOnTriggerDown[1] = "Fire";
	stateTransitionOnNoAmmo[1]      = "Empty";
	stateAllowImageChange[1]        = true;
	stateTimeoutValue[1]		        = 0.01;

	stateName[2]                    = "Fire";
	stateTransitionOnTriggerUp[2]   = "CockAmmo";
	stateTimeoutValue[2]            = 0.4;
	stateFire[2]                    = true;
	stateAllowImageChange[2]        = false;
	stateSequence[2]                = "fire";
	stateScript[2]                  = "onFire";
	stateWaitForTimeout[2]		     = true;
	stateEmitter[2]			        = GenericShotgunFlashEmitter;
	stateEmitterTime[2]		        = 0.05;
	stateEmitterNode[2]		        = "muzzleNode";
	stateSound[2]			           = GenericMossbergShotgunFireSound;

	stateName[3]                     = "AmmoCheck";
	stateTransitionOnTimeout[3]      = "Ready";
	stateAllowImageChange[3]         = true;
	stateScript[3]                   = "onAmmoCheck";

	stateName[4]			           = "Cocking";
	stateTimeoutValue[4]		        = 0.6;
	stateSequence[4]			        = "cock";
	stateTransitionOnTimeout[4]	  = "Wait";
	stateScript[4]                  = "onCock";
	stateSequence[4]				= "pump";
	stateWaitForTimeout[4]		     = true;
	stateEjectShell[4]       	     = true;
	stateSound[4]                   = GenericMossbergShotgunPumpSound;

	stateName[5]                    = "CockAmmo";
	stateTimeoutValue[5]            = 0.6;
	stateSequence[5]                = "cock";
	stateTransitionOnTimeout[5]     = "Wait";
	statescript[5]                  = "onCockAmmo";
	stateWaitForTimeout[5]          = true;
	stateEjectShell[5]              = true;
	stateSequence[5]				= "pump";
	stateSound[5]                   = GenericMossbergShotgunPumpSound;

	stateName[6]                    = "Reload";
	stateTimeoutValue[6]		        = 0.3;
	stateTransitionOnTriggerDown[6] = "Cocking";
	stateWaitForTimeout[6]			= true;
	stateScript[6]                  = "onReloadSingle";
	stateSequence[6]				= "insertBullet";
	stateTransitionOnTimeout[6]	  = "Wait2";

	stateName[7]                     = "CheckChamber";
	stateTransitionOnTriggerDown[7]  = "ReloadEnd";
	stateTransitionOnTimeout[7]      = "Reload";
	stateTransitionOnAmmo[7]         = "ReloadEnd";
	stateScript[7]                   = "onCheckChamber";
	stateAllowImageChange[7]         = false;
	stateWaitForTimeout[7]           = true;

	stateName[8]                     = "Empty";
	stateAllowImageChange[8]         = true;
	stateScript[8]                   = "onEmpty";
	stateTransitionOnAmmo[8]         = "ReloadStart";

	stateName[10]                    = "Wait";
	stateTimeoutValue[10]            = 0.3;
	stateTransitionOnTimeout[10]     = "AmmoCheck";
	stateWaitForTimeout[10]         = true;

	stateName[11]                    = "Wait2";
	stateTimeoutValue[11]            = 0.01;
	stateTransitionOnTimeout[11]     = "CheckChamber";
	stateWaitForTimeout[11]          = true;

	stateName[12]						= "ReloadStart";
	stateSequence[12]					= "reloadStart";
	stateTimeoutValue[12]				= 0.2;
	stateTransitionOnTimeout[12]		= "Reload";

	stateName[13]						= "ReloadEnd";
	stateSequence[13]					= "reloadEnd";
	stateTransitionOnTimeout[13]		= "Cocking";
	stateTimeoutValue[13]				= 0.1;
};


function GenericMossbergShotgunImage::onReloadSingle( %this, %obj, %slot )
{
	%obj.playThread(2,shiftRight);
	%rnd = getRandom(1, 3);
	serverPlay3d( GenericMossbergShotgunShellSound @ %rnd, %obj.getHackPosition() );
	GenericDisplayAmmo(%this,%obj,%slot);
	GenericAmmoOnReloadSingle(%this,%obj,%slot);
}

function GenericMossbergShotgunImage::onAmmoCheck( %this, %obj, %slot )
{
	GenericAmmoCheck(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot);
}

function GenericMossbergShotgunImage::onCheckChamber( %this, %obj, %slot )
{
	if(%obj.toolMag[%obj.currTool] > %this.item.maxmag)
	{
		%obj.toolMag[%obj.currTool] = %this.item.maxmag;
		%obj.setImageAmmo(0,1);
	}
	GenericDisplayAmmo(%this,%obj,%slot);
}

function GenericMossbergShotgunImage::onCock( %this, %obj, %slot )
{
	%obj.playThread(2,plant);
	%obj.setImageAmmo(0,1);
	GenericDisplayAmmo(%this,%obj,%slot);
}

function GenericMossbergShotgunImage::onCockAmmo( %this, %obj, %slot )
{
	%obj.playThread(2,plant);
	GenericDisplayAmmo(%this,%obj,%slot);
}

function GenericMossbergShotgunImage::onMount( %this, %obj, %slot )
{
	parent::onMount(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot,0);
}
function GenericMossbergShotgunImage::onUnMount( %this, %obj, %slot )
{
	parent::onUnMount(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot,-1);
}

function GenericMossbergShotgunImage::onEmpty(%this,%obj,%slot)
{
	if( $GenericWeapons::Ammo && %obj.toolAmmo[%this.item.ammotype] < 1 )
	{
		return;
	}

	if(%obj.toolMag[%obj.currTool] < 1)
	{
		serverCmdLight(%obj.client);
	}
}

function GenericMossbergShotgunImage::onEmptyFire(%this,%obj,%slot)
{
	%obj.playThread(2,plant);
	// %this.onEmpty(%obj,%slot);
}

function GenericMossbergShotgunImage::onFire( %this, %obj, %slot )
{
	if(%obj.getDamagePercent() > 1.0)
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

	%obj.spawnExplosion(GenericRecoilMediumProjectile, "1 1 1");
	serverPlay3d( "GenericMossbergShotgunFire" @ getRandom(1,2) @ "Sound", %obj.getHackPosition() );
}

function GenericMossbergShotgunImage::onRaycastCollision( %this, %obj, %col, %pos, %normal, %vec )
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

	parent::onRaycastCollision( %this, %obj, %col, %pos, %normal, %vec );
}