using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveParticleControl : MonoBehaviour {

	private ParticleSystem system;

	public class PolarPos {
		public float radius;
		public float angle;

		public float X { get { return Mathf.Cos(angle) * radius; } }
		public float Z { get { return Mathf.Sin(angle) * radius; } }
	}

	[System.Serializable]
	public class SinInfo {
		public float A;
		public float omega;
		// public float phase;
		public SinInfo(float A, float omega) {
			this.A = A;
			this.omega = omega;
		}
	}

	[System.Serializable]
	public class WaveInfo {
		public Transform startPoint;
		public Color color;
		public SinInfo sinInfo;
	}
	public WaveInfo[] waveInfos;
	public bool showOri = true;

	private ParticleSystem.Particle[] particles;
	private List<Vector3[]> pos;
	private Dictionary<Vector2Int, List<float>> map;

	public bool showCompound = false;
	public Color compoundColor = Color.cyan;

	private Vector3[] compoundPos;

	public float size = 0.03f;
	public float speed = 0.1f;
	public float delta = 0.05f;
	public int dirCount = 12;
	public int particleCountPerWave = 5000;
	public float decreasingSpeed = 0.1f;

	private int count { get { return (waveInfos.Length + 1) * particleCountPerWave; } }

	// Use this for initialization
	void Start () {
		map = new Dictionary<Vector2Int, List<float>>();
		pos = new List<Vector3[]>();
		for (int i = 0; i < waveInfos.Length; ++i) {
			pos.Add(new Vector3[particleCountPerWave]);
		}

		compoundPos = new Vector3[particleCountPerWave * waveInfos.Length];

		particles = new ParticleSystem.Particle[count];
		system = GetComponent<ParticleSystem>();

		var main = system.main;
		main.startSpeed = 0f;
		main.startSize = size;
		main.startColor = new Color(1f, 1f, 1f, 0f);
		main.maxParticles = count;
		system.Emit(count);
		system.GetParticles(particles);
	}


	private float offset = 0f;
	void CalcParticlesPos() {
		int particlesPerDir = 0;
		float perAngle = 0;
		particlesPerDir = particleCountPerWave / dirCount;
		perAngle = 2 * Mathf.PI / dirCount;

		for (int waveIndex = 0; waveIndex < waveInfos.Length; ++waveIndex) {
			for (int i = 0; i < dirCount; ++i) {
				for (int j = 0; j < particlesPerDir; ++j) {
					PolarPos particlesPos = new PolarPos();
					particlesPos.radius = j * delta;
					particlesPos.angle = i * perAngle;

					var index = i * particlesPerDir + j;
					var x = particlesPos.X + waveInfos[waveIndex].startPoint.position.x;
					var y = Mathf.Clamp(
										waveInfos[waveIndex].sinInfo.A - (particlesPos.radius * decreasingSpeed),
										0f,
										waveInfos[waveIndex].sinInfo.A)
								* Mathf.Sin((particlesPos.radius - offset) * waveInfos[waveIndex].sinInfo.omega);
					var z = particlesPos.Z + waveInfos[waveIndex].startPoint.position.z;

					pos[waveIndex][index] = new Vector3(x, y, z);
				}
			}
		}
	}

	private int compoundPosCount = 0;
	void CalcCompound() {
		int particlesPerDir = particleCountPerWave / dirCount;
		float perAngle = 2 * Mathf.PI / dirCount;
		Vector3 startPoint = (waveInfos[0].startPoint.position + waveInfos[1].startPoint.position) / 2;

		for (int i = 0; i < dirCount; ++i) {
			for (int j = 0; j < particlesPerDir; ++j) {
				PolarPos particlesPos = new PolarPos();
				particlesPos.radius = j * delta;
				particlesPos.angle = i * perAngle;

				var index = i * particlesPerDir + j;
				var x = particlesPos.X + startPoint.x;
				var z = particlesPos.Z + startPoint.z;
				var x0 = waveInfos[0].startPoint.position.x;
				var y0 = waveInfos[0].startPoint.position.y;
				var z0 = waveInfos[0].startPoint.position.z;
				var x1 = waveInfos[1].startPoint.position.x;
				var y1 = waveInfos[1].startPoint.position.y;
				var z1 = waveInfos[1].startPoint.position.z;
				var r0 = Mathf.Sqrt(Mathf.Pow(x - x0, 2) + Mathf.Pow(z - z0, 2));
				var r1 = Mathf.Sqrt(Mathf.Pow(x - x1, 2) + Mathf.Pow(z - z1, 2));
				var y = Mathf.Clamp(waveInfos[0].sinInfo.A - r0 * decreasingSpeed, 0f, waveInfos[0].sinInfo.A)
							* Mathf.Sin(waveInfos[0].sinInfo.omega
							* (r0 - offset)) + y0

							+ Mathf.Clamp(waveInfos[1].sinInfo.A - r1 * decreasingSpeed, 0f, waveInfos[1].sinInfo.A)
							* Mathf.Sin(waveInfos[1].sinInfo.omega
							* (r1 - offset)) + y1;

				compoundPos[index] = new Vector3(x, y, z);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		map.Clear();

		int particleCurIndex = 0;

		// calc all pos
		CalcParticlesPos();

		if (showOri) {
			// show partiles
			for (int waveIndex = 0; waveIndex < waveInfos.Length; ++waveIndex) {
				for (int i = 0; i < particleCountPerWave; ++i) {
					particles[particleCurIndex].startColor = waveInfos[waveIndex].color;

					particles[particleCurIndex].position = pos[waveIndex][i];
					++particleCurIndex;
				}
			}
		}

		if (showCompound) {
			// calc compound pos
			CalcCompound();

			// show compound particles
			for (int i = 0; i < particleCountPerWave; ++i) {
				particles[particleCurIndex].startColor = compoundColor;

				particles[particleCurIndex].position = compoundPos[i];
				++particleCurIndex;
			}
		}

		// Hide particles not used
		for (; particleCurIndex < particles.Length; ++particleCurIndex) {
			particles[particleCurIndex].startColor = new Color(1f, 1f, 1f, 0f);
		}

		system.SetParticles(particles, particles.Length);

		offset += speed;
	}
}
