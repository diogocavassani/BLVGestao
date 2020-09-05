using System;

namespace BLVGestao.Domain.Model
{
    //TODO:Verificar necessidade desta classe
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
