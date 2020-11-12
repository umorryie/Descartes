﻿using Descartes.Contex;
using Descartes.Controllers;
using Descartes.DifferenceDeterminator;
using Descartes.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Descartes.Repository
{
    public class DifferenceRepository: IDifferenceRepository
    {
        private IDifferenceDeterminatorResolver _differenceDeterminator;
        private DiffContext _diffContext;
        public DifferenceRepository(IDifferenceDeterminatorResolver differenceDeterminator, DiffContext diffContext)
        {
            _differenceDeterminator = differenceDeterminator;
            _diffContext = diffContext;
        }

        public string determineDifferences(int id)
        {
            DifferenceObject response = _diffContext.DifferenceObject.FirstOrDefault<DifferenceObject>(diffObject => diffObject.Id == id);

            return response != null ? response.DiffResult.ToString() : "No differences";
        }

        private string saveRight(RequestDifferenceInputHelper requestInput, int id)
        {
            try
            {
                DifferenceObject result = getAllDatabaseContent().FirstOrDefault<DifferenceObject>(diffObject => diffObject.Id == id);


                if (result == null)
                {
                    DifferenceObject diffObject = new DifferenceObject() 
                    {
                        RightValue = requestInput.data,
                        Id = id
                    };

                    _diffContext.DifferenceObject.Add(diffObject);
                }
                else
                {
                    result.RightValue = requestInput.data;
                    result.DiffResult = JsonConvert.SerializeObject(_differenceDeterminator.determineDifferences(result.LeftValue, result.RightValue));
                }

                _diffContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return "";
        }

        private string saveLeft(RequestDifferenceInputHelper requestInput, int id)
        {
            try
            {
                DifferenceObject result = getAllDatabaseContent().FirstOrDefault<DifferenceObject>(diffObject => diffObject.Id == id);

                if (result == null)
                {
                    DifferenceObject diffObject = new DifferenceObject()
                    {
                        LeftValue = requestInput.data,
                        Id = id
                    };

                    _diffContext.DifferenceObject.Add(diffObject);
                }
                else
                {
                    result.LeftValue = requestInput.data;
                    result.DiffResult = JsonConvert.SerializeObject(_differenceDeterminator.determineDifferences(result.LeftValue, result.RightValue));
                }

                _diffContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return "";
        }

        public string saveObject(string identifier, RequestDifferenceInputHelper requestInput, int id)
        {
            return identifier == "left" ? saveLeft(requestInput, id) : saveRight(requestInput, id);
        }

        public List<DifferenceObject> getAllDatabaseContent()
        {
            return _diffContext.DifferenceObject.ToList<DifferenceObject>();
        }
    }
}
