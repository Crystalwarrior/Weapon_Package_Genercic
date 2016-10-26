
datablock AudioProfile(GenericEmptySound)
{
	filename = "./res/sounds/shared/generic_empty.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(GenericSightsInSound)
{
	filename = "./res/sounds/shared/generic_zoomin.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(GenericSightsOutSound)
{
	filename = "./res/sounds/shared/generic_zoomout.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(GenericActivate1Sound)
{
	filename = "./res/sounds/shared/generic_activate-01.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(GenericActivate2Sound)
{
	filename = "./res/sounds/shared/generic_activate-02.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(GenericActivate3Sound)
{
	filename = "./res/sounds/shared/generic_activate-03.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(GenericBulletHitSound1)
{
	filename    = "./res/sounds/Physics/bullet_impact.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(GenericBulletHitSound2)
{
	filename    = "./res/sounds/Physics/bullet_impact2.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(GenericBulletHitSound3)
{
	filename    = "./res/sounds/Physics/bullet_impact3.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(GenericBulletHitSound4)
{
	filename    = "./res/sounds/Physics/bullet_impact4.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(GenericfleshHitSound1)
{
	filename    = "./res/sounds/Physics/flesh_impact_bullet.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(GenericfleshHitSound2)
{
	filename    = "./res/sounds/Physics/flesh_impact_bullet2.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(GenericfleshHitSound3)
{
	filename    = "./res/sounds/Physics/flesh_impact_bullet3.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(GenericfleshHitSound4)
{
	filename    = "./res/sounds/Physics/flesh_impact_bullet4.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock ParticleData(GenericExplosionParticle)
{
	dragCoefficient      = 8;
	gravityCoefficient   = -0.1;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 5000;
	lifetimeVarianceMS   = 500;
	textureName          = "base/data/particles/cloud";
	spinSpeed		= 10.0;
	spinRandomMin		= -50.0;
	spinRandomMax		= 50.0;
	colors[0]     = "0.6 0.6 0.6 0.8";
	colors[1]     = "0.5 0.5 0.5 0.0";
	sizes[0]      = 0.75;
	sizes[1]      = 2;
	useInvAlpha = true;
};
datablock ParticleEmitterData(GenericExplosionEmitter)
{
   lifeTimeMS		= 30;
   ejectionPeriodMS = 3;
   periodVarianceMS = 0;
   ejectionVelocity = 3;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 10;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;
   particles = "GenericExplosionParticle";
};
datablock ParticleData(GenericExplosion2Particle)
{
	dragCoefficient      = 0;
	gravityCoefficient   = 5.0;
	inheritedVelFactor   = 0.0;
	constantAcceleration = 0.0;
	lifetimeMS           = 100;
	lifetimeVarianceMS   = 60;
	textureName          = "base/data/particles/chunk";
	spinSpeed		= 10.0;
	spinRandomMin		= -500.0;
	spinRandomMax		= 500.0;
	colors[0]     = "0.01 0.01 0.01 0.9";
	colors[1]     = "0.01 0.01 0.01 0.6";
	sizes[0]      = 0.1;
	sizes[1]      = 0.1;
	useInvAlpha = true;
};
datablock ParticleEmitterData(GenericExplosion2Emitter)
{
   ejectionPeriodMS = 15;
   periodVarianceMS = 2;
   ejectionVelocity = 15;
   velocityVariance = 2;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;
   particles = "GenericExplosion2Particle";
};
//}
datablock ExplosionData(GenericImpactExplosion)
{
	// soundProfile = bullethitSound;
	lifeTimeMS = 150;
	particleEmitter = GenericExplosionEmitter;
	particleDensity = 5;
	particleRadius = 0.2;
	emitter[0] = GenericExplosion2Emitter;
	faceViewer     = true;
	explosionScale = "1 1 1";
	shakeCamera = true;
	camShakeFreq = "0.0 1.0 1.0";
	camShakeAmp = "0.0 1.0 1.5";
	camShakeDuration = 0.5;
	camShakeRadius = 0.5;
	lightStartRadius = 0;
	lightEndRadius = 0;
};

datablock ParticleData(GenericBloodExplosion2Particle)
{
	dragCoefficient      = 0;
	gravityCoefficient   = 5.0;
	inheritedVelFactor   = 0.0;
	constantAcceleration = 0.0;
	lifetimeMS           = 100;
	lifetimeVarianceMS   = 60;
	textureName          = "base/data/particles/chunk";
	spinSpeed		= 10.0;
	spinRandomMin		= -500.0;
	spinRandomMax		= 500.0;
	colors[0]     = "0.71 0.01 0.01 0.9";
	colors[1]     = "0.71 0.01 0.01 0.6";
	sizes[0]      = 0.1;
	sizes[1]      = 0.1;
	useInvAlpha = true;
};
datablock ParticleEmitterData(GenericBloodExplosion2Emitter)
{
   ejectionPeriodMS = 15;
   periodVarianceMS = 2;
   ejectionVelocity = 4;
   velocityVariance = 2;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;
   particles = "GenericBloodExplosion2Particle";
};

datablock ExplosionData(GenericPlayerImpactExplosion)
{
	// soundProfile = bullethitSound;
	lifeTimeMS = 150;
	particleEmitter = GenericBloodExplosion2Emitter;
	particleDensity = 5;
	particleRadius = 0.2;
	faceViewer     = true;
	explosionScale = "1 1 1";
	shakeCamera = false;
	camShakeFreq = "0.0 1.0 1.0";
	camShakeAmp = "0.0 3.0 2.5";
	camShakeDuration = 0.5;
	camShakeRadius = 0.5;
	lightStartRadius = 0;
	lightEndRadius = 0;
};

datablock ProjectileData(GenericPlayerImpactProjectile)
{
	explosion = GenericPlayerImpactExplosion;
};

datablock ExplosionData(GenericRecoilSmallExplosion)
{
	lifeTimeMS = 150;
	shakeCamera = true;
	camShakeFreq = "1 0 1";
	camShakeAmp = "1 0 1";
	camShakeDuration = 1;
	camShakeRadius = 0.5;
};
datablock ProjectileData(GenericRecoilSmallProjectile)
{
	explosion = GenericRecoilSmallExplosion;
};

datablock ExplosionData(GenericRecoilMediumExplosion)
{
	lifeTimeMS = 250;
	shakeCamera = true;
	camShakeFreq = "1 0 1";
	camShakeAmp = "2 0 2";
	camShakeDuration = 2;
	camShakeRadius = 0.5;
};
datablock ProjectileData(GenericRecoilMediumProjectile)
{
	explosion = GenericRecoilMediumExplosion;
};
//shell
datablock DebrisData(GenericPistolShellDebris)
{
	shapeFile = "./res/shapes/shell_9mm.dts";
	lifetime = 12.0;
	minSpinSpeed = -400.0;
	maxSpinSpeed = 200.0;
	elasticity = 0.5;
	friction = 0.2;
	numBounces = 3;
	staticOnMaxBounce = true;
	snapOnMaxBounce = false;
	fade = true;

	gravModifier = 2;
};
datablock DebrisData(GenericShotgunShellDebris : GenericPistolShellDebris)
{
	shapeFile = "./res/shapes/shell_buckshot.dts";
};

datablock ParticleData(GenericPistolSmokeParticle)
{
	dragCoefficient      = 8;
	gravityCoefficient   = -0.4;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 1525;
	lifetimeVarianceMS   = 155;
	textureName          = "base/data/particles/cloud";
	spinSpeed      = 10.0;
	spinRandomMin     = -50.0;
	spinRandomMax     = 50.0;
	colors[0]     = "0.1 0.1 0.1 0.9";
	colors[1]     = "0.5 0.5 0.5 0.0";
	sizes[0]      = 0.15;
	sizes[1]      = 0.35;

	useInvAlpha = false;
};
datablock ParticleEmitterData(GenericPistolSmokeEmitter)
{
	ejectionPeriodMS = 5;
	periodVarianceMS = 0;
	ejectionVelocity = 1.0;
	velocityVariance = 1.0;
	ejectionOffset   = 0.0;
	thetaMin         = 0;
	thetaMax         = 90;
	phiReferenceVel  = 0;
	phiVariance      = 90;
	overrideAdvance = false;
	particles = "GenericPistolSmokeParticle";
};
//muzzle flash effects
datablock ParticleData(GenericPistolFlashParticle)
{
	dragCoefficient      = 3;
	gravityCoefficient   = -0.5;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 64;
	lifetimeVarianceMS   = 0;
	textureName          = "./res/shapes/generic_muzzle_bw.png";
	spinSpeed      = 10.0;
	spinRandomMin     = -500.0;
	spinRandomMax     = 500.0;
	colors[0]     = "0.8 0.5 0.0 0.9";
	colors[1]     = "0.7 0.3 0.0 0.0";
	sizes[0]      = 0.5;
	sizes[1]      = 1.0;

	useInvAlpha = false;
};
datablock ParticleEmitterData(GenericPistolFlashEmitter)
{
	ejectionPeriodMS = 3;
	periodVarianceMS = 0;
	ejectionVelocity = 1.0;
	velocityVariance = 1.0;
	ejectionOffset   = 0.0;
	thetaMin         = 0;
	thetaMax         = 90;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "GenericPistolFlashParticle";
};

//muzzle flash effects
datablock ParticleData(GenericShotgunFlashParticle : GenericPistolFlashParticle)
{
	lifetimeMS           = 64;
	lifetimeVarianceMS   = 0;
	sizes[0]      = 1;
	sizes[1]      = 2.0;
};

datablock ParticleEmitterData(GenericShotgunFlashEmitter : GenericPistolFlashEmitter)
{
	ejectionPeriodMS = 3;
	particles = "GenericShotgunFlashParticle";
};


datablock ProjectileData(GenericProjectile)
{
	projectileShapeName = "Add-Ons/Weapon_Gun/bullet.dts";
	directDamage        = 0;//8;
	directDamageType    = $DamageType::Direct;
	radiusDamageType    = $DamageType::Direct;

	brickExplosionRadius = 0;
	brickExplosionImpact = false;          //destroy a brick if we hit it directly?
	// brickExplosionForce  = 10;
	// brickExplosionMaxVolume = 1;          //max volume of bricks that we can destroy
	// brickExplosionMaxVolumeFloating = 2;  //max volume of bricks that we can destroy if they aren't connected to the ground

	impactImpulse       = 0;
	verticalImpulse     = 0;
	explosion           = GenericImpactExplosion;
	particleEmitter     = ""; //bulletTrailEmitter;

	muzzleVelocity      = 200;
	velInheritFactor    = 1;

	armingDelay         = 00;
	lifetime            = 400;
	fadeDelay           = 100;
	bounceElasticity    = 0.5;
	bounceFriction      = 0.20;
	isBallistic         = false;
	gravityMod = 0.0;

	hasLight    = false;
	lightRadius = 3.0;
	lightColor  = "0 0 0.5";
};

datablock staticShapeData(GenericTracerShapeData)
{
	shapeFile = "./res/shapes/tracer.dts";
	tracerThread = "root";
};

datablock staticShapeData( gunShotShapeData )
{
	shapeFile = "./res/shapes/bullethole.dts";
	doColorShift = true;
	colorShiftColor = "0.6 0.6 0.6 1";
};