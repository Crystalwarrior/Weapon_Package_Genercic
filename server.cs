$LastError = forceRequiredAddOn("Weapon_Gun");

if ($LastError == $Error::AddOn_Disabled)
{
	GunItem.uiName = "";
}

if ($LastError == $Error::AddOn_NotFound)
{
	error("ERROR: Weapon_Package_Generic - required add-on Weapon_Gun not found");
	return;
}

package GenericSupportPackage
{
	function Player::mountImage(%obj, %image, %slot)
	{
		%obj.lastImage[%slot] = %obj.getMountedImage(%slot);
		Parent::mountImage(%obj, %image, %slot);

		if (%slot == 0)
		{
			%obj.lastMntImage = %obj.getMountedImage(%slot);
			%obj.lastMntTime = $Sim::Time;
		}
	}
};

activatePackage(GenericSupportPackage);

$GenericWeapons::ShowAmmo = 1;
$GenericWeapons::Ammo = 1;
$GenericWeapons::ammoSystem = 1;

$GenericWeapons::MaxAmmo["9mm"] = 170;
$GenericWeapons::AddAmmo["9mm"] = 17;
$GenericWeapons::StarterAmmo["9mm"] = 85;

$GenericWeapons::MaxAmmo["smg"] = 160;
$GenericWeapons::AddAmmo["smg"] = 32;
$GenericWeapons::StarterAmmo["smg"] = 96;

$GenericWeapons::MaxAmmo["Buckshot"] = 30;
$GenericWeapons::AddAmmo["Buckshot"] = 6;
$GenericWeapons::StarterAmmo["Buckshot"] = 18;

$GenericWeapons::MaxAmmo["Sniper Ammo"] = 30;
$GenericWeapons::AddAmmo["Sniper Ammo"] = 8;
$GenericWeapons::StarterAmmo["Sniper Ammo"] = 16;

$GenericWeapons::MaxAmmo["big boleet"] = 36;
$GenericWeapons::AddAmmo["big boleet"] = 6;
$GenericWeapons::StarterAmmo["big boleet"] = 18;

exec("./lib/raycasts.cs");
exec("./lib/lagComp.cs");
exec("./lib/ammoSystem.cs");
exec("./lib/decals.cs");

exec("./datablocks.cs");
exec("./Weapon_Pistol_Glock17.cs");
exec("./Weapon_SMG_Shipka.cs");
exec("./Weapon_Shotgun_Mossberg.cs");
exec("./Weapon_Sniper_Lizzy.cs");
exec("./Weapon_Revolver_Colt.cs");

exec("./Item_Health_Kit.cs");