datablock ItemData(HealthKitItem)
{
	uiName = "Health Kit";
	shapeFile = "./res/shapes/i_healthkit.dts";
	emap = 1;
};

function HealthKitItem::onPickup(%this, %obj, %player)
{
	if (isEventPending(%obj.fadeIn) || %player.getDamageLevel() <= 0)
	{
		return;
	}

	%obj.fadeOut();
	%obj.fadeIn = %obj.schedule(5000, fadeIn);

	%player.setDamageLevel(0);
	serverPlay3D(GenericGlock17Fire1Sound, %obj.getPosition());
}