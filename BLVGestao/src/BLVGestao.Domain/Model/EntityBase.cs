using System;

namespace BLVGestao.Domain.Model
{

    public class EntityBase
    {
        public EntityBase()
        {
            Ativo = true;
        }
        public bool Ativo { get; protected set; }

        public void Inativar()
        {
            Ativo = false;
        }
        public void Ativar()
        {
            Ativo = true;
        }
    }
}
