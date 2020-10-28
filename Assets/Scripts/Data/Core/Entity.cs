using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Entities
{
    public abstract class Entity
    {
        protected string _name;
        protected GameObject _body;
        protected GameObject _avatar;
        protected GameObject _skin;
        protected float _hitpoint;

        protected GameObject SetForm(string name)
        {
            return Resources.Load<GameObject>("Prefabs/" + name);
        }

        protected void CreateAvatar()
        {
            _avatar = Object.Instantiate(_body);
            _avatar.name = _name;
        }

        protected GameObject ChangeSkin(string name)
        {
            return Resources.Load<GameObject>("Prefabs/Skins/" + name);
        }
    }
}

