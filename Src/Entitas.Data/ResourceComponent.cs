﻿using System;
using System.Collections.Generic;
using Entitas.CodeGeneration.Attributes;
using Util;

namespace Entitas.Data
{
    public delegate void CollisionDelegate(uint targetEntityId);

    public sealed class IdComponent : IComponent
    {
        [PrimaryEntityIndex]public uint value;
    }

    public sealed class ResourceComponent : IComponent
    {
        public uint Value;
    }
    public sealed class AIComponent : IComponent
    {
        public behaviac.Agent Agent;
    }
    public sealed class PhysicsComponent : IComponent
    {
        public RigidObject Rigid;
        public Vector3 Offset;
    }
    public sealed class CollisionComponent : IComponent
    {
        public RigidObject Rigid;
        public Vector3 Offset;
        public CollisionDelegate OnCollision;
    }
    public sealed class CampComponent : IComponent
    {
        public int Value;
    }

    public sealed class DestoryComponent : IComponent
    {
    }
    public sealed class AttrComponent : IComponent
    {
        public int Id;
        public AttributeData Value;
    }
    public sealed class BuffAttrChangedComponent : IComponent
    {
    }
    public sealed class HpComponent : IComponent
    {
        public float Value;
    }
    public sealed class DeadComponent : IComponent
    {
        public float DeadTime;
    }
    public sealed class BornComponent : IComponent
    {
        public float BornTime;
    }
}
