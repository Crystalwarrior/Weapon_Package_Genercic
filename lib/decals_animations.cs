function fadeAnimationLoop(%this, %time, %scale) {
	cancel(%this.fadeAnimationLoop);
	if (!isObject(%this)) {
		return;
	}
	if (%scale $= "") {
		%scale = %this.getScale();
	}
	if (%scale <= 0.1) {
		%this.delete();
		return;
	}
	if (!%time || %time == 0) {
		%time = 16;
	}

	%scale = vectorSub(%scale, "0.15 0.15 0.15");
	%this.setScale(%scale);
	%this.fadeAnimationLoop = schedule(%time, 0, fadeAnimationLoop, %this, %time, %this.getScale());
}