// <auto-generated>
//   This file was generated by a tool; you should avoid making direct changes.
//   Consider using 'partial classes' to extend these types
//   Input: engine_gcmessages.proto
// </auto-generated>

#region Designer generated code
#pragma warning disable CS0612, CS0618, CS1591, CS3021, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
namespace Core.Models.protobuf
{

    [global::ProtoBuf.ProtoContract()]
    public partial class CEngineGotvSyncPacket : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"match_id")]
        public ulong MatchId
        {
            get => __pbn__MatchId.GetValueOrDefault();
            set => __pbn__MatchId = value;
        }
        public bool ShouldSerializeMatchId() => __pbn__MatchId != null;
        public void ResetMatchId() => __pbn__MatchId = null;
        private ulong? __pbn__MatchId;

        [global::ProtoBuf.ProtoMember(2, Name = @"instance_id")]
        public uint InstanceId
        {
            get => __pbn__InstanceId.GetValueOrDefault();
            set => __pbn__InstanceId = value;
        }
        public bool ShouldSerializeInstanceId() => __pbn__InstanceId != null;
        public void ResetInstanceId() => __pbn__InstanceId = null;
        private uint? __pbn__InstanceId;

        [global::ProtoBuf.ProtoMember(3, Name = @"signupfragment")]
        public uint Signupfragment
        {
            get => __pbn__Signupfragment.GetValueOrDefault();
            set => __pbn__Signupfragment = value;
        }
        public bool ShouldSerializeSignupfragment() => __pbn__Signupfragment != null;
        public void ResetSignupfragment() => __pbn__Signupfragment = null;
        private uint? __pbn__Signupfragment;

        [global::ProtoBuf.ProtoMember(4, Name = @"currentfragment")]
        public uint Currentfragment
        {
            get => __pbn__Currentfragment.GetValueOrDefault();
            set => __pbn__Currentfragment = value;
        }
        public bool ShouldSerializeCurrentfragment() => __pbn__Currentfragment != null;
        public void ResetCurrentfragment() => __pbn__Currentfragment = null;
        private uint? __pbn__Currentfragment;

        [global::ProtoBuf.ProtoMember(5, Name = @"tickrate")]
        public float Tickrate
        {
            get => __pbn__Tickrate.GetValueOrDefault();
            set => __pbn__Tickrate = value;
        }
        public bool ShouldSerializeTickrate() => __pbn__Tickrate != null;
        public void ResetTickrate() => __pbn__Tickrate = null;
        private float? __pbn__Tickrate;

        [global::ProtoBuf.ProtoMember(6, Name = @"tick")]
        public uint Tick
        {
            get => __pbn__Tick.GetValueOrDefault();
            set => __pbn__Tick = value;
        }
        public bool ShouldSerializeTick() => __pbn__Tick != null;
        public void ResetTick() => __pbn__Tick = null;
        private uint? __pbn__Tick;

        [global::ProtoBuf.ProtoMember(8, Name = @"rtdelay")]
        public float Rtdelay
        {
            get => __pbn__Rtdelay.GetValueOrDefault();
            set => __pbn__Rtdelay = value;
        }
        public bool ShouldSerializeRtdelay() => __pbn__Rtdelay != null;
        public void ResetRtdelay() => __pbn__Rtdelay = null;
        private float? __pbn__Rtdelay;

        [global::ProtoBuf.ProtoMember(9, Name = @"rcvage")]
        public float Rcvage
        {
            get => __pbn__Rcvage.GetValueOrDefault();
            set => __pbn__Rcvage = value;
        }
        public bool ShouldSerializeRcvage() => __pbn__Rcvage != null;
        public void ResetRcvage() => __pbn__Rcvage = null;
        private float? __pbn__Rcvage;

        [global::ProtoBuf.ProtoMember(10, Name = @"keyframe_interval")]
        public float KeyframeInterval
        {
            get => __pbn__KeyframeInterval.GetValueOrDefault();
            set => __pbn__KeyframeInterval = value;
        }
        public bool ShouldSerializeKeyframeInterval() => __pbn__KeyframeInterval != null;
        public void ResetKeyframeInterval() => __pbn__KeyframeInterval = null;
        private float? __pbn__KeyframeInterval;

        [global::ProtoBuf.ProtoMember(11, Name = @"cdndelay")]
        public uint Cdndelay
        {
            get => __pbn__Cdndelay.GetValueOrDefault();
            set => __pbn__Cdndelay = value;
        }
        public bool ShouldSerializeCdndelay() => __pbn__Cdndelay != null;
        public void ResetCdndelay() => __pbn__Cdndelay = null;
        private uint? __pbn__Cdndelay;

    }

}

#pragma warning restore CS0612, CS0618, CS1591, CS3021, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
#endregion
