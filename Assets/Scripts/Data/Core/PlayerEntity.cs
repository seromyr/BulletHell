using Entities;
using Constants;
using UnityEngine;

public class PlayerEntity : Entity
{
    public string Name { get { return _name; } }
    public GameObject Form { get { return _body; } }
    public GameObject Avatar { get { return _avatar; } }

    public PlayerEntity()
    {
        _body = SetForm(PrimeObj.PLAYER);
        _name = PrimeObj.PLAYER;

        CreateAvatar();

        // Add default skin
        _skin = Object.Instantiate(ChangeSkin(PlayerSkin.DEFAULT), _avatar.transform);
        _skin.name = PlayerSkin.DEFAULT;

        // Assign Player class
        _avatar.AddComponent<Player>();
    }
}