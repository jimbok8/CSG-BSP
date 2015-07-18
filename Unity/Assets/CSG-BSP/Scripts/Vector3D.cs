﻿using UnityEngine;
using System.Collections;

public struct Vector3D
{
	public float X;
	public float Y;
	public float Z;

	public Vector3D(float x, float y, float z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public Vector3D(Vector3D src)
	{
		X = src.X;
		Y = src.Y;
		Z = src.Z;
	}

	public Vector3D(float[] elements)
	{
		if(elements != null && elements.Length >= 3)
		{
			X = elements[0];
			Y = elements[1];
			Z = elements[2];
		}
		else
		{
			X = 0;
			Y = 0;
			Z = 0;
		}
	}

	public static float Dot(Vector3D a, Vector3D b)
	{
		return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
	}

	public float Dot(Vector3D b)
	{
		return Dot (this, b);
	}

	public static Vector3D Cross(Vector3D a, Vector3D b)
	{
		return new Vector3D(a.Y * b.Z - a.Z * b.Y,
							a.Z * b.X - a.X * b.Z,
							a.X * b.Y - a.Y * b.X);
	}
	
	public Vector3D Cross(Vector3D b)
	{
		return Cross (this, b);
	}

	public float Magnitude()
	{
		return Mathf.Sqrt (Dot (this, this));
	}

	public void Normalize()
	{
		float mag = Magnitude ();
		if(mag == 0.0f)return;
		MultiplyBy (1.0f / mag);
	}

	public Vector3D Normalized()
	{
		Vector3D normalized = new Vector3D(this);
		normalized.Normalize ();
		return normalized;
	}

	public void Invert()
	{
		X = -X;
		Y = -Y;
		Z = -Z;
	}

	public Vector3D Inverted()
	{
		Vector3D inverted = new Vector3D(this);
		inverted.Invert ();
		return inverted;
	}

	public Vector3D Lerped(Vector3D dest, float t)
	{
		return new Vector3D(this).AddedWith(dest.SubtractedBy (this).MultipliedBy (t));
	}

	public void Subtract(Vector3D b)
	{
		this.X -= b.X;
		this.Y -= b.Y;
		this.Z -= b.Z;
	}

	public Vector3D SubtractedBy(Vector3D b)
	{
		Vector3D subtracted = new Vector3D (this);
		subtracted.Subtract (b);
		return b;
	}

	public void Add(Vector3D b)
	{
		this.X += b.X;
		this.Y += b.Y;
		this.Z += b.Z;
	}
	
	public Vector3D AddedWith(Vector3D b)
	{
		Vector3D added = new Vector3D (this);
		added.Add (b);
		return b;
	}

	public void MultiplyBy(float factor)
	{
		X *= factor;
		Y *= factor;
		Z *= factor;
	}
	
	public Vector3D MultipliedBy(float factor)
	{
		Vector3D multiplied = new Vector3D(this);
		multiplied.MultiplyBy (factor);
		return multiplied;
	}
}
