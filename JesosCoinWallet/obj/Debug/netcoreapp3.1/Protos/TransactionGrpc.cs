// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/transaction.proto
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
  public static partial class TransactionService
  {
    static readonly string __ServiceName = "TransactionService";

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
    static readonly grpc::Marshaller<global::JesosCoinNode.Grpc.TransactionPost> __Marshaller_TransactionPost = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::JesosCoinNode.Grpc.TransactionPost.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::JesosCoinNode.Grpc.TransactionStatus> __Marshaller_TransactionStatus = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::JesosCoinNode.Grpc.TransactionStatus.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::JesosCoinNode.Grpc.Transaction> __Marshaller_Transaction = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::JesosCoinNode.Grpc.Transaction.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::JesosCoinNode.Grpc.TransactionPaging> __Marshaller_TransactionPaging = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::JesosCoinNode.Grpc.TransactionPaging.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::JesosCoinNode.Grpc.TransactionList> __Marshaller_TransactionList = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::JesosCoinNode.Grpc.TransactionList.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::JesosCoinNode.Grpc.TransactionPost, global::JesosCoinNode.Grpc.TransactionStatus> __Method_Receive = new grpc::Method<global::JesosCoinNode.Grpc.TransactionPost, global::JesosCoinNode.Grpc.TransactionStatus>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Receive",
        __Marshaller_TransactionPost,
        __Marshaller_TransactionStatus);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::JesosCoinNode.Grpc.TransactionPost, global::JesosCoinNode.Grpc.TransactionStatus> __Method_Transfer = new grpc::Method<global::JesosCoinNode.Grpc.TransactionPost, global::JesosCoinNode.Grpc.TransactionStatus>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Transfer",
        __Marshaller_TransactionPost,
        __Marshaller_TransactionStatus);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::JesosCoinNode.Grpc.Transaction, global::JesosCoinNode.Grpc.Transaction> __Method_GetByHash = new grpc::Method<global::JesosCoinNode.Grpc.Transaction, global::JesosCoinNode.Grpc.Transaction>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetByHash",
        __Marshaller_Transaction,
        __Marshaller_Transaction);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::JesosCoinNode.Grpc.TransactionPaging, global::JesosCoinNode.Grpc.TransactionList> __Method_GetRangeByAddress = new grpc::Method<global::JesosCoinNode.Grpc.TransactionPaging, global::JesosCoinNode.Grpc.TransactionList>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetRangeByAddress",
        __Marshaller_TransactionPaging,
        __Marshaller_TransactionList);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::JesosCoinNode.Grpc.TransactionPaging, global::JesosCoinNode.Grpc.TransactionList> __Method_GetRange = new grpc::Method<global::JesosCoinNode.Grpc.TransactionPaging, global::JesosCoinNode.Grpc.TransactionList>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetRange",
        __Marshaller_TransactionPaging,
        __Marshaller_TransactionList);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::JesosCoinNode.Grpc.TransactionPaging, global::JesosCoinNode.Grpc.TransactionList> __Method_GetPoolRange = new grpc::Method<global::JesosCoinNode.Grpc.TransactionPaging, global::JesosCoinNode.Grpc.TransactionList>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetPoolRange",
        __Marshaller_TransactionPaging,
        __Marshaller_TransactionList);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::JesosCoinNode.Grpc.TransactionPaging, global::JesosCoinNode.Grpc.TransactionList> __Method_GetPendingTxns = new grpc::Method<global::JesosCoinNode.Grpc.TransactionPaging, global::JesosCoinNode.Grpc.TransactionList>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetPendingTxns",
        __Marshaller_TransactionPaging,
        __Marshaller_TransactionList);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::JesosCoinNode.Grpc.TransactionReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for TransactionService</summary>
    public partial class TransactionServiceClient : grpc::ClientBase<TransactionServiceClient>
    {
      /// <summary>Creates a new client for TransactionService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public TransactionServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for TransactionService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public TransactionServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected TransactionServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected TransactionServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.TransactionStatus Receive(global::JesosCoinNode.Grpc.TransactionPost request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Receive(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.TransactionStatus Receive(global::JesosCoinNode.Grpc.TransactionPost request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Receive, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.TransactionStatus> ReceiveAsync(global::JesosCoinNode.Grpc.TransactionPost request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ReceiveAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.TransactionStatus> ReceiveAsync(global::JesosCoinNode.Grpc.TransactionPost request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Receive, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.TransactionStatus Transfer(global::JesosCoinNode.Grpc.TransactionPost request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Transfer(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.TransactionStatus Transfer(global::JesosCoinNode.Grpc.TransactionPost request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Transfer, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.TransactionStatus> TransferAsync(global::JesosCoinNode.Grpc.TransactionPost request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return TransferAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.TransactionStatus> TransferAsync(global::JesosCoinNode.Grpc.TransactionPost request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Transfer, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.Transaction GetByHash(global::JesosCoinNode.Grpc.Transaction request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetByHash(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.Transaction GetByHash(global::JesosCoinNode.Grpc.Transaction request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetByHash, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.Transaction> GetByHashAsync(global::JesosCoinNode.Grpc.Transaction request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetByHashAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.Transaction> GetByHashAsync(global::JesosCoinNode.Grpc.Transaction request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetByHash, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.TransactionList GetRangeByAddress(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetRangeByAddress(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.TransactionList GetRangeByAddress(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetRangeByAddress, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.TransactionList> GetRangeByAddressAsync(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetRangeByAddressAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.TransactionList> GetRangeByAddressAsync(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetRangeByAddress, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.TransactionList GetRange(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetRange(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.TransactionList GetRange(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetRange, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.TransactionList> GetRangeAsync(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetRangeAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.TransactionList> GetRangeAsync(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetRange, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.TransactionList GetPoolRange(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetPoolRange(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.TransactionList GetPoolRange(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetPoolRange, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.TransactionList> GetPoolRangeAsync(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetPoolRangeAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.TransactionList> GetPoolRangeAsync(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetPoolRange, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.TransactionList GetPendingTxns(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetPendingTxns(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::JesosCoinNode.Grpc.TransactionList GetPendingTxns(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetPendingTxns, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.TransactionList> GetPendingTxnsAsync(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetPendingTxnsAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::JesosCoinNode.Grpc.TransactionList> GetPendingTxnsAsync(global::JesosCoinNode.Grpc.TransactionPaging request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetPendingTxns, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override TransactionServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new TransactionServiceClient(configuration);
      }
    }

  }
}
#endregion
