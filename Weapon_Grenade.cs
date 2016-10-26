//sounds
datablock AudioProfile(GenericGlock17Fire1Sound)
{
	filename    = "./res/sounds/pistol/pistol_fire01.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(GenericGlock17Fire2Sound)
{
	filename    = "./res/sounds/pistol/pistol_fire02.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(GenericGlock17ReloadSound)
{
	filename    = "./res/sounds/pistol/pistol_reload.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(GenericGlock17ActivateSound)
{
	filename    = "./res/sounds/pistol/pistol_activate.wav";
	description = AudioClosest3d;
	preload = true;
};

AddDamageType("GenericGlock17",   '<bitmap:add-ons/Weapon_Pack_Generic/res/shapes/icons/CI_Pistol> %1',    '%2 <bitmap:add-ons/Weapon_Pack_Generic/res/shapes/icons/CI_Pistol> %1',0.2,1);
datablock ProjectileData(GenericGlock17Projectile : GenericProjectile)
{
	directDamageType    = $DamageType::GenericGlock17;
	radiusDamageType    = $DamageType::GenericGlock17;
};

//////////
// item //
//////////
datablock ItemData(GenericGlock17Item)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = "./res/shapes/i_glock17.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "Pistol - Glock17";
	//iconName = "./icons/icon_Pistol";
	doColorShift = false;
	colorShiftColor = "0.25 0.25 0.25 1.000";

	maxmag = 17;
	ammotype = "9mm";
	reload = true;

	 // Dynamic properties defined by the scripts
	image = GenericGlock17Image;
	canDrop = true;
};

////////////////
//weapon image//
////////////////
datablock ShapeBaseImageData(GenericGlock17Image)
{
	// Basic Item properties
	shapeFile = "./res/shapes/w_glock17.dts";
	emap = true;

	// Specify mount point & offset for 3rd person, and eye offset
	// for first person rendering.
	mountPoint = 0;
	offset = "0 0 0";
	eyeOffset = "0.7 1.2 -0.5";
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
	item = GenericGlock17Item;
	ammo = " ";
	projectile = GenericGlock17Projectile;
	projectileType = Projectile;


	raycastEnabled = 1;
	raycastRange = 200;
	raycastHitExplosion = GenericGlock17Projectile;
	raycastHitPlayerExplosion = GenericPlayerImpactProjectile;

	directDamage = 25; //10
	directDamageType = $DamageType::GenericPistol;

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
	stateName[0]						= "Activate";
	stateTimeoutValue[0]				= 0.25;
	stateTransitionOnTimeout[0]			= "AmmoCheck";
	stateSound[0]						= "";
	stateSequence[0]					= "Activate";

	stateName[1]						= "Ready";
	stateTransitionOnNoAmmo[1]			= "Empty";
	stateTransitionOnTriggerDown[1]		= "Fire";
	stateAllowImageChange[1]			= true;

	stateName[2]						= "Fire";
	stateTransitionOnTriggerUp[2]		= "Smoke";
	stateTimeoutValue[2]				= 0.12;
	stateFire[2]						= true;
	stateAllowImageChange[2]			= false;
	stateSequence[2]					= "Fire";
	stateScript[2]						= "onFire";
	stateWaitForTimeout[2]				= true;
	stateEmitter[2]						= GenericPistolFlashEmitter;
	stateEmitterTime[2]					= 0.05;
	stateEmitterNode[2]					= "muzzleNode";
	stateEjectShell[2]					= true;

	stateName[3]						= "AmmoCheck";
	stateTransitionOnTimeout[3]			= "Ready";
	stateAllowImageChange[3]			= true;
	stateScript[3]						= "onAmmoCheck";

	stateName[4]						= "Reload";
	stateTransitionOnTimeout[4]			= "ReloadReady";
	stateTimeoutValue[4]				= 0.85;
	stateAllowImageChange[4]			= false;
	stateScript[4]						= "onReloadStart";
	stateSequence[4]					= "Reload";
	stateSound[4]						= GenericGlock17ReloadSound;

	stateName[5]						= "ReloadReady";
	stateTransitionOnTimeout[5]			= "CheckChamber";
	stateTimeoutValue[5]				= 0.1;
	stateAllowImageChange[5]			= false;
	stateScript[5]						= "onReload";
	stateSequence[5]					= "";

	stateName[6]						= "Empty";
	stateTransitionOnTriggerDown[6]		= "EmptyFire";
	stateAllowImageChange[6]			= true;
	tateTransitionOnAmmo[7]				= "Reload";
	stateScript[6]						= "onEmpty";
	stateTransitionOnAmmo[6]			= "Reload";
	//stateSequence[6]					= "empty";

	stateName[7]						= "EmptyFire";
	stateTransitionOnTriggerUp[7]		= "Empty";
	stateTimeoutValue[7]				= 0.13;
	stateAllowImageChange[7]			= false;
	stateWaitForTimeout[7]				= true;
	stateSound[7]						= GenericEmptySound;
	stateSequence[7]					= "emptyFire";
	stateScript[7]						= "onEmptyFire";

	stateName[8]						= "CheckChamber";
	stateTransitionOnTimeOut[8]			= "Ready";
	stateTransitionOnNoAmmo[8]			= "Cocking";
	stateAllowImageChange[8]			= true;

	stateName[9]						= "Cocking";
	stateTransitionOnTimeOut[9]			= "Ready";
	stateTimeoutValue[9]				= 0.1;
	stateAllowImageChange[9]			= true;
	stateWaitForTimeout[9]				= true;
	stateSound[9]						= "";
	stateScript[9]						= "onCock";

	stateName[10]						= "Smoke";
	stateEmitter[10]					= GenericPistolSmokeEmitter;
	stateTransitionOnTimeOut[10]		= "AmmoCheck";
	stateEmitterTime[10]				= 0.15;
	stateEmitterNode[10]				= "muzzleNode";
};

function GenericGlock17Image::onReloadStart( %this, %obj, %slot )
{
	%obj.playThread(2,shiftRight);
	GenericDisplayAmmo(%this,%obj,%slot);
}

function GenericGlock17Image::onAmmoCheck( %this, %obj, %slot )
{
	GenericAmmoCheck(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot);
}

function GenericGlock17Image::onReload( %this, %obj, %slot )
{
	%obj.playThread(2,plant);
	GenericAmmoOnReload(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot);
}

function GenericGlock17Image::onCock( %this, %obj, %slot )
{
	%obj.playThread(2,shiftLeft);
	%obj.setImageAmmo(0,1);
	GenericDisplayAmmo(%this,%obj,%slot);
}

function GenericGlock17Image::onMount( %this, %obj, %slot )
{
	if(%obj.lastMntImage == nameToID(GenericGlock17SightsImage)) {
		%sound = GenericSightsOutSound;
	}
	else {
		%sound = GenericGlock17ActivateSound;
		%obj.playThread(1, armReadyRight);
	}
	if($Sim::Time - %obj.lastMntTime <= 0.1) {
		%sound = "";
	}
	parent::onMount(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot,0);
	serverPlay3D(%sound, %obj.getHackPosition());
}
function GenericGlock17Image::onUnMount( %this, %obj, %slot )
{
	parent::onUnMount(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot,-1);
}

function GenericGlock17Image::onEmpty(%this,%obj,%slot)
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

function GenericGlock17Image::onEmptyFire(%this,%obj,%slot)
{
	%obj.playThread(2,plant);
	// %this.onEmpty(%obj,%slot);
}

function GenericGlock17Image::onFire( %this, %obj, %slot )
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
	if(%obj.getMountedImage(0) == nameToID(GenericGlock17Image))
		%shake = "0.5 0.5 0.5";
	else
		%shake = "0.25 0.25 0.25";

	%obj.spawnExplosion(GenericRecoilSmallProjectile, %shake);
	serverPlay3d( "GenericGlock17Fire" @ getRandom(1,2) @ "Sound", %obj.getHackPosition() );
}

function GenericGlock17Image::onRaycastCollision(%this, %obj, %col, %pos, %normal, %vec)
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

datablock ShapeBaseImageData(GenericGlock17SightsImage : GenericGlock17Image)
{
	eyeOffset = "0 1.2 -0.37";
	raycastSpread = 1.5;

	stateSound[0] = genericSightsInSound;
	stateSequence[0] = "ZoomIn";
};

function GenericGlock17SightsImage::onReloadStart( %this, %obj, %slot )
{
	GenericGlock17Image::onReloadStart( %this, %obj, %slot );
}
function GenericGlock17SightsImage::onAmmoCheck( %this, %obj, %slot )
{
	GenericGlock17Image::onAmmoCheck( %this, %obj, %slot );
}
function GenericGlock17SightsImage::onReload( %this, %obj, %slot )
{
	GenericGlock17Image::onReload( %this, %obj, %slot );
}
function GenericGlock17SightsImage::onCock( %this, %obj, %slot )
{
	GenericGlock17Image::onCock( %this, %obj, %slot );
}
function GenericGlock17SightsImage::onMount( %this, %obj, %slot )
{
	parent::onMount(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot,0);
	// serverPlay3D(%sound, %obj.getHackPosition());
}
function GenericGlock17SightsImage::onUnMount( %this, %obj, %slot )
{
	parent::onUnMount(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot,-1);
}
function GenericGlock17SightsImage::onEmpty(%this,%obj,%slot)
{
	GenericGlock17Image::onEmpty(%this,%obj,%slot);
}
function GenericGlock17SightsImage::onFire( %this, %obj, %slot )
{
	GenericGlock17Image::onFire( %this, %obj, %slot );
}
function GenericGlock17SightsImage::onRaycastCollision( %this, %obj, %col, %pos, %normal, %vec)
{
	GenericGlock17Image::onRaycastCollision( %this, %obj, %col, %pos, %normal, %vec);
}
function GenericGlock17SightsImage::onRaycastDamage(%this,%obj,%slot,%col,%pos,%normal,%shotVec,%crit)
{
	GenericGlock17Image::onRaycastDamage(%this,%obj,%slot,%col,%pos,%normal,%shotVec,%crit);
}
function GenericGlock17SightsImage::onEmptyFire(%this,%obj,%slot)
{
	GenericGlock17Image::onEmptyFire(%this,%obj,%slot);
}

package GenericPistolPackage
{
	function Armor::onTrigger(%this, %obj, %slot, %state)
	{
		Parent::onTrigger(%this, %obj, %slot, %state);
		if(%obj.getMountedImage(0) != nameToID(GenericGlock17Image) && %obj.getMountedImage(0) != nameToID(GenericGlock17SightsImage))
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
				%obj.mountImage(GenericGlock17SightsImage, 0);
			}
			else {
				// %obj.playThread(3, shiftRight);
				%obj.mountImage(GenericGlock17Image, 0);
			}
		}
	}
	function serverCmdUnuseTool(%this) 
	{
		if(isObject(%this.player) && %this.player.getMountedImage(0) == nameToID(GenericGlock17SightsImage)) {
			return;
		}
		parent::serverCmdUnuseTool(%this);
	}
};
activatePackage(GenericPistolPackage);