﻿using GestaoFuncionarios.Model.Interfaces;
using GestaoFuncionarios.Model.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Dados.Repositorio
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : class, IEntity
    {
        protected readonly Contexto contexto;

        public BaseRepositorio(Contexto _contexto)
        {
            contexto = _contexto;
        }

        public virtual bool Incluir(T entity)
        {
            try
            {
                contexto.Set<T>().Add(entity);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public virtual bool Alterar(T entity)
        {
            contexto.Set<T>().Update(entity);
            contexto.SaveChanges();
            return true;
        }

        public virtual T SelecionarPorId(int id)
        {
            return contexto.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public virtual List<T> SelecionarTudo()
        {
            return contexto.Set<T>().ToList();
        }

        public virtual bool Deletar(T entity)
        {
            contexto.Set<T>().Remove(entity);
            contexto.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

    }
}
