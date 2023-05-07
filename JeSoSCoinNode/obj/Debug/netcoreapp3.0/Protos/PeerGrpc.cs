// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/peer.proto
// </auto-generated>
// Original file comments:
// Created by I Putu Kusuma Negara. markbrain2013[at]gmail.com
// 
// Ubudkuscoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.
//
// In developement by Scryce Programmer - jesos.org@hotmail.com - Abr 2023
// Repository: https://github.com/JesosCoin/JeSoSCoinCore
//
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace JesosCoinNode.Grpc {
  public static partial class PeerService
  {
    static readonly string __ServiceName = "PeerService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::JesosCoinNode.Grpc.Peer> __Marshaller_Peer = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::JesosCoinNode.Grpc.Peer.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::JesosCoinNode.Grpc.AddPeerReply> __Marshaller_AddPeerReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::JesosCoinNode.Grpc.AddPeerReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::JesosCoinNode.Grpc.PeerPaging> __Marshaller_PeerPaging = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::JesosCoinNode.Grpc.PeerPaging.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::JesosCoinNode.Grpc.PeerList> __Marshaller_PeerList = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::JesosCoinNode.Grpc.PeerList.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::JesosCoinNode.Grpc.NodeParam> __Marshaller_NodeParam = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::JesosCoinNode.Grpc.NodeParam.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::JesosCoinNode.Grpc.NodeState> __Marshaller_NodeState = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::JesosCoinNode.Grpc.NodeState.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::JesosCoinNode.Grpc.Peer, global::JesosCoinNode.Grpc.AddPeerReply> __Method_Add = new grpc::Method<global::JesosCoinNode.Grpc.Peer, global::JesosCoinNode.Grpc.AddPeerReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Add",
        __Marshaller_Peer,
        __Marshaller_AddPeerReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::JesosCoinNode.Grpc.PeerPaging, global::JesosCoinNode.Grpc.PeerList> __Method_GetAll = new grpc::Method<global::JesosCoinNode.Grpc.PeerPaging, global::JesosCoinNode.Grpc.PeerList>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAll",
        __Marshaller_PeerPaging,
        __Marshaller_PeerList);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::JesosCoinNode.Grpc.NodeParam, global::JesosCoinNode.Grpc.NodeState> __Method_GetNodeState = new grpc::Method<global::JesosCoinNode.Grpc.NodeParam, global::JesosCoinNode.Grpc.NodeState>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetNodeState",
        __Marshaller_NodeParam,
        __Marshaller_NodeState);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::JesosCoinNode.Grpc.PeerReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of PeerService</summary>
    [grpc::BindServiceMethod(typeof(PeerService), "BindService")]
    public abstract partial class PeerServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::JesosCoinNode.Grpc.AddPeerReply> Add(global::JesosCoinNode.Grpc.Peer request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::JesosCoinNode.Grpc.PeerList> GetAll(global::JesosCoinNode.Grpc.PeerPaging request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::JesosCoinNode.Grpc.NodeState> GetNodeState(global::JesosCoinNode.Grpc.NodeParam request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for PeerService</summary>
    public partial class PeerServiceClient : grpc::ClientBase<PeerServiceClient>
    {
      /// <summary>Creates a new client for PeerService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public PeerServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for PeerService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public PeerServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected PeerServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected PeerServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.AddPeerReply Add(global::JesosCoinNode.Grpc.Peer request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Add(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.AddPeerReply Add(global::JesosCoinNode.Grpc.Peer request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Add, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.AddPeerReply> AddAsync(global::JesosCoinNode.Grpc.Peer request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.AddPeerReply> AddAsync(global::JesosCoinNode.Grpc.Peer request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Add, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.PeerList GetAll(global::JesosCoinNode.Grpc.PeerPaging request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAll(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.PeerList GetAll(global::JesosCoinNode.Grpc.PeerPaging request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAll, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.PeerList> GetAllAsync(global::JesosCoinNode.Grpc.PeerPaging request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.PeerList> GetAllAsync(global::JesosCoinNode.Grpc.PeerPaging request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAll, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.NodeState GetNodeState(global::JesosCoinNode.Grpc.NodeParam request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetNodeState(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.NodeState GetNodeState(global::JesosCoinNode.Grpc.NodeParam request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetNodeState, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.NodeState> GetNodeStateAsync(global::JesosCoinNode.Grpc.NodeParam request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetNodeStateAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.NodeState> GetNodeStateAsync(global::JesosCoinNode.Grpc.NodeParam request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetNodeState, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override PeerServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new PeerServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(PeerServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Add, serviceImpl.Add)
          .AddMethod(__Method_GetAll, serviceImpl.GetAll)
          .AddMethod(__Method_GetNodeState, serviceImpl.GetNodeState).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, PeerServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Add, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::JesosCoinNode.Grpc.Peer, global::JesosCoinNode.Grpc.AddPeerReply>(serviceImpl.Add));
      serviceBinder.AddMethod(__Method_GetAll, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::JesosCoinNode.Grpc.PeerPaging, global::JesosCoinNode.Grpc.PeerList>(serviceImpl.GetAll));
      serviceBinder.AddMethod(__Method_GetNodeState, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::JesosCoinNode.Grpc.NodeParam, global::JesosCoinNode.Grpc.NodeState>(serviceImpl.GetNodeState));
    }

  }
}
#endregion