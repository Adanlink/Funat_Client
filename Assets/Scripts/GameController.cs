using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.IoC;
using Assets.Scripts.UserInterface.Message;
using Autofac;
using ChickenAPI.Core.Utils;
using EntityController;
using EntityController.Entity.Interfaces;
using MessagePack;
using MessagePack.Resolvers;
using Networking;
using Networking.Packets;
using Networking.Packets.Handlers;
using Networking.Packets.Handlers.LoginRegisterMenu;
using Networking.Serializers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UserInterface.GameMenu;
using UserInterface.Message;

public class GameController : MonoBehaviour
{
    public INetworkController NetworkController { get; set; }
    
    public ISceneController SceneController { get; set; }

    public MessageController _MessageController;

    public IMessageController MessageController { get; set; }

    public HudController _HudController;
    
    public IHudController HudController { get; set; }

    public EntitiesController _EntitiesController;
    
    public IEntitiesController EntitiesController { get; set; }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("GameController").Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        PrepareContainer();
        InitializeContainer();
        SetUpControllers();
    }

    void Update()
    {
        SceneController.Update();
    }

    void OnApplicationQuit()
    {
        NetworkController?.Disconnect();
    }

    private void PrepareContainer()
    {
        UsefulContainer.Builder.RegisterType<NetworkController>().As<INetworkController>().SingleInstance();
        UsefulContainer.Builder.RegisterType<SceneController>().As<ISceneController>().SingleInstance();
        UsefulContainer.Builder.RegisterInstance(MessageController = Instantiate(_MessageController, GetComponent<Transform>()).GetComponent<IMessageController>()).As<IMessageController>().SingleInstance();
        UsefulContainer.Builder.RegisterInstance(HudController = Instantiate(_HudController, GetComponent<Transform>()).GetComponent<IHudController>()).As<IHudController>().SingleInstance();
        UsefulContainer.Builder.RegisterInstance(EntitiesController = Instantiate(_EntitiesController, GetComponent<Transform>()).GetComponent<IEntitiesController>()).As<IEntitiesController>().SingleInstance();
        UsefulContainer.Builder.RegisterType<MessagePackGameSerializer>().As<ISerializer>();
        //
        StaticCompositeResolver.Instance.Register(
            MessagePack.Resolvers.GeneratedResolver.Instance,
            MessagePack.Resolvers.StandardResolver.Instance
        );

        var option = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance);
        
        MessagePackSerializer.DefaultOptions = option;
        //
        UsefulContainer.Builder.RegisterType<PacketFactory>().As<IPacketFactory>().SingleInstance();
        UsefulContainer.Builder.RegisterInstance(this).As<GameController>().SingleInstance();
        UsefulContainer.Builder.RegisterAssemblyTypes(new LoginFailedHandler(null).GetType().Assembly).AsClosedTypesOf(typeof(GenericPacketHandlerAsync<>)).PropertiesAutowired();
        /*CompositeResolver.Register(
                new IMessagePackFormatter[]
                {
                    //PrimitiveObjectFormatter.Instance,
                    NullableStringFormatter.Instance,
                    new DynamicObjectTypeFallbackFormatter(new IFormatterResolver[] { GeneratedResolver.Instance })
                },
                new IFormatterResolver[]
                {
                    //StandardResolver.Instance,
                    GeneratedResolver.Instance,
                });*/
        //UsefulContainer.Builder.RegisterInstance(CompositeResolver.Instance).As<IFormatterResolver>();
    }

    private void InitializeContainer()
    {
        UsefulContainer.Initialize();
    }

    private void SetUpControllers()
    {
        NetworkController = UsefulContainer.Instance.Resolve<INetworkController>();
        SceneController = UsefulContainer.Instance.Resolve<ISceneController>();
    }
}