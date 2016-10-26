addDamageType("GenericSniper", '<bitmap:add-ons/Weapon_Pack_Generic/res/shapes/icons/CI_Sniper> %1', '%2 <bitmap:add-ons/Weapon_Pack_Generic/res/shapes/icons/CI_Sniper> %1', 0.2, 1);

datablock ProjectileData(GenericSniperProjectile : GenericProjectile)
{
	directDamageType = $DamageType::GenericSniper;
	radiusDamageType = $DamageType::GenericSniper;
};

datablock ItemData(GenericSniperItem)
{
	category = "Weapon";
	className = "Weapon";

	shapeFile = "./res/shapes/i_glock17.dts";
	emap = 1;

	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;

	doColorShift = 0;
	colorShiftColor = "0.25 0.25 0.25 1.000";

	reload = 1;
	maxMag = 1;
	ammoType = "Sniper Ammo";

	uiName = "Sniper R. - Lizzy";
	canDrop = 1;
	image = GenericSniperImage;
};

datablock ShapeBaseImageData(GenericSniperImage)
{
	className = "WeaponImage";

	shapeFile = "./res/shapes/w_sniper_lizzy.dts";
	emap = 1;

	mountPoint = 0;
	offset = "0 0 0";
	eyeOffset = "0.7 0.75 -0.75";
	rotation = eulerToMatrix("0 0 0");

	correctMuzzleVector = 1;
	item = GenericSniperItem;

	raycastEnabled = 1;
	raycastRange = 300;
	raycastHitExplosion = GenericSniperProjectile;
	raycastHitPlayerExplosion = GenericPlayerImpactProjectile;

	directDamage = 45;
	directDamageType = $DamageType::GenericSniper;

	raycastSpread = 1;
	raycastCount = 1;

	raycastTracer = GenericTracerShapeData;
	raycastTracerTime = 64;
	raycastTracerSize = 0.5;
	raycastTracerColor = "0.9 0.5 0.1 1";

	casing = GenericGlock17ShellDebris;
	shellExitDir = "0.5 -1.3 0.5";
	shellExitOffset = "0 0 0";
	shellExitVariance = 15;
	shellVelocity = 7;

	melee = 0;
	armReady = 1;

	doColorShift = GenericSniperItem.doColorShift;
	colorShiftColor = GenericSniperItem.colorShiftColor;

	stateName[0]						= "Activate";
	stateTimeoutValue[0]				= 0.4;
	stateTransitionOnTimeout[0]			= "AmmoCheck";
	stateSequence[0]					= "Activate";

	stateName[1]						= "Ready";
	stateTransitionOnNoAmmo[1]			= "Empty";
	stateTransitionOnTriggerDown[1]		= "Fire";
	stateAllowImageChange[1]			= true;

	stateName[2]						= "Fire";
	stateTransitionOnTriggerUp[2]		= "Smoke";
	stateTimeoutValue[2]				= 0.3;
	stateFire[2]						= true;
	stateAllowImageChange[2]			= false;
	stateSequence[2]					= "Fire";
	stateScript[2]						= "onFire";
	stateWaitForTimeout[2]				= true;
	stateEmitter[2]						= GenericGlock17FlashEmitter;
	stateEmitterTime[2]					= 0.05;
	stateEmitterNode[2]					= "muzzleNode";
	stateEjectShell[2]					= true;

	stateName[3]						= "AmmoCheck";
	stateTransitionOnTimeout[3]			= "Ready";
	stateAllowImageChange[3]			= true;
	stateScript[3]						= "onAmmoCheck";

	stateName[4]						= "Reload";
	stateTransitionOnTimeout[4]			= "ReloadReady";
	stateTimeoutValue[4]				= 1.4;
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
	stateAllowImageChange[6]			= 1;
	stateScript[6]						= "onEmpty";
	stateTransitionOnAmmo[6]			= "Reload";

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
	stateEmitter[10]					= GenericGlock17SmokeEmitter;
	stateTransitionOnTimeOut[10]		= "AmmoCheck";
	stateEmitterTime[10]				= 0.4;
	stateEmitterNode[10]				= "muzzleNode";
};

datablock ShapeBaseImageData(GenericSniperSightsImage : GenericSniperImage)
{
	eyeOffset = "0 1.2 -0.37";
	raycastSpread = 0;

	stateSound[0] = genericSightsInSound;
	stateSequence[0] = "ZoomIn";
};

function GenericSniperImage::onReloadStart( %this, %obj, %slot )
{
	%obj.playThread(2,shiftRight);
	GenericDisplayAmmo(%this,%obj,%slot);
}

function GenericSniperImage::onAmmoCheck( %this, %obj, %slot )
{
	GenericAmmoCheck(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot);
}

function GenericSniperImage::onReload( %this, %obj, %slot )
{
	%obj.playThread(2,plant);
	GenericAmmoOnReload(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot);
}

function GenericSniperImage::onCock( %this, %obj, %slot )
{
	%obj.playThread(2,shiftLeft);
	%obj.setImageAmmo(0,1);
	GenericDisplayAmmo(%this,%obj,%slot);
}

function GenericSniperImage::onMount( %this, %obj, %slot )
{
	if(%obj.lastMntImage == nameToID(GenericSniperSightsImage)) {
		%sound = GenericSightsOutSound;
	}
	else {
		%sound = GenericSniperActivateSound;
		%obj.playThread(1, armReadyRight);
	}
	if($Sim::Time - %obj.lastMntTime <= 0.1) {
		%sound = "";
	}
	parent::onMount(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot,0);
	serverPlay3D(%sound, %obj.getHackPosition());
}
function GenericSniperImage::onUnMount( %this, %obj, %slot )
{
	parent::onUnMount(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot,-1);
}

function GenericSniperImage::onEmpty(%this,%obj,%slot)
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

function GenericSniperImage::onEmptyFire(%this,%obj,%slot)
{
	%obj.playThread(2,plant);
	// %this.onEmpty(%obj,%slot);
}

function GenericSniperImage::onFire( %this, %obj, %slot )
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
	if(%obj.getMountedImage(0) == nameToID(GenericSniperImage))
		%shake = "0.5 0.5 0.5";
	else
		%shake = "0.25 0.25 0.25";

	%obj.spawnExplosion(GenericRecoilSmallProjectile, %shake);
	serverPlay3d( "GenericSniperFire" @ getRandom(1,2) @ "Sound", %obj.getHackPosition() );
}

function GenericSniperImage::onRaycastCollision(%this, %obj, %col, %pos, %normal, %vec)
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

function GenericSniperSightsImage::onReloadStart( %this, %obj, %slot )
{
	GenericSniperImage::onReloadStart( %this, %obj, %slot );
}
function GenericSniperSightsImage::onAmmoCheck( %this, %obj, %slot )
{
	GenericSniperImage::onAmmoCheck( %this, %obj, %slot );
}
function GenericSniperSightsImage::onReload( %this, %obj, %slot )
{
	GenericSniperImage::onReload( %this, %obj, %slot );
}
function GenericSniperSightsImage::onCock( %this, %obj, %slot )
{
	GenericSniperImage::onCock( %this, %obj, %slot );
}
function GenericSniperSightsImage::onMount( %this, %obj, %slot )
{
	parent::onMount(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot,0);
	// serverPlay3D(%sound, %obj.getHackPosition());
}
function GenericSniperSightsImage::onUnMount( %this, %obj, %slot )
{
	parent::onUnMount(%this,%obj,%slot);
	GenericDisplayAmmo(%this,%obj,%slot,-1);
}
function GenericSniperSightsImage::onEmpty(%this,%obj,%slot)
{
	GenericSniperImage::onEmpty(%this,%obj,%slot);
}
function GenericSniperSightsImage::onFire( %this, %obj, %slot )
{
	GenericSniperImage::onFire( %this, %obj, %slot );
}
function GenericSniperSightsImage::onRaycastCollision( %this, %obj, %col, %pos, %normal, %vec)
{
	GenericSniperImage::onRaycastCollision( %this, %obj, %col, %pos, %normal, %vec);
}
function GenericSniperSightsImage::onRaycastDamage(%this,%obj,%slot,%col,%pos,%normal,%shotVec,%crit)
{
	GenericSniperImage::onRaycastDamage(%this,%obj,%slot,%col,%pos,%normal,%shotVec,%crit);
}
function GenericSniperSightsImage::onEmptyFire(%this,%obj,%slot)
{
	GenericSniperImage::onEmptyFire(%this,%obj,%slot);
}

package GenericSniperPackage
{
	function Armor::onTrigger(%this, %obj, %slot, %state)
	{
		Parent::onTrigger(%this, %obj, %slot, %state);
		if(%obj.getMountedImage(0) != nameToID(GenericSniperImage) && %obj.getMountedImage(0) != nameToID(GenericSniperSightsImage))
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
				%obj.mountImage(GenericSniperSightsImage, 0);
			}
			else {
				// %obj.playThread(3, shiftRight);
				%obj.mountImage(GenericSniperImage, 0);
			}
		}
	}
	function serverCmdUnuseTool(%this) 
	{
		if(isObject(%this.player) && %this.player.getMountedImage(0) == nameToID(GenericSniperSightsImage)) {
			return;
		}
		parent::serverCmdUnuseTool(%this);
	}
};
activatePackage(GenericSniperPackage);