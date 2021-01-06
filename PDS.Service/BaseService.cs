using PDS.Data;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Service
{
    public class BaseService<T> where T : class, PDS.Domain.IData
    {
        public RepositoryBase<T> _repo;
        protected readonly PDSDBUnitOfWork _uow;
        protected readonly UserService _userService;

        public BaseService()
        {
            _uow = new PDSDBUnitOfWork();
            _userService = new UserService();
        }

        public List<T> Gets(int? id = null)
        {
            try
            {
                var x = id.HasValue ?
                    _repo.Get(i => i.Id == id).ToList() :
                    _repo.Get().ToList();
                return x;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<T> Gets(List<int> ids)
        {
            return
                _repo.Get(i => ids.Contains(i.Id)).ToList();
        }

        public virtual void Add(T entity, bool save = true)
        {
            try
            {
                UpdateData(entity);

                if (entity.Id == 0)
                    _repo.Add(entity);
                else
                {
                    _repo.Update(entity);
                }
                   

                if (save) _uow.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public void AddRange(List<T> entities, bool save = true)
        {
            try
            {
                entities.ForEach(entity => UpdateData(entity));

                foreach (var entity in entities)
                {
                    if (entity.Id == 0)
                        _repo.Add(entity);
                    else if (entity.Id == -1)
                        _repo.Delete(entity);
                    else
                        _repo.Update(entity);
                }

                if (save) _uow.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public void Remove(T entity, bool save = true)
        {
            try
            {
                _repo.Delete(entity);
                if (save) _uow.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
        public void RemoveRange(List<T> entities, bool save = true)
        {
            try
            {
                entities.ForEach(entity => _repo.Delete(entity));
                if (save) _uow.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }


        public void UpdateData(IData Data)
        {
            Data.UpdatedBy = _userService.UserName;
            Data.UpdatedOn = DateTime.Now;
            if (Data.Id == 0)
            {
                Data.CreatedBy = _userService.UserName;
                Data.CreatedOn = DateTime.Now;
            }
        }
    }
}
