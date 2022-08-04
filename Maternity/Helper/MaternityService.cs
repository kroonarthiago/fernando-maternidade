using Maternity.Models;
using Maternity.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maternity.Helper
{
    public class MaternityService
    {
        public class Baby
        {
            public BabyModel Get(int BabyId)
            {
                var BabyModel = new BabyModel();
                try
                {

                    using (var Context = new MaternityEntities())
                    {
                        var Baby = Context.Baby.FirstOrDefault(f => f.Id == BabyId);

                        if (Baby == null)
                            throw new Exception("Ocorreu um erro ao requisitar os dados de usuário.");

                        BabyModel.Id = Baby.Id;
                        BabyModel.Name = Baby.Name;
                        BabyModel.BirthDate = Baby.BirthDate;
                        BabyModel.Weight = Baby.Weight;
                        BabyModel.Height = Baby.Height;
                        BabyModel.MotherId = Baby.MotherId;

                    }
                }
                catch (Exception Ex)
                {
                    BabyModel.Id = -1;
                }

                return BabyModel;
            }

            public bool Update(BabyModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new MaternityEntities())
                    {
                        var Entity = Context.Baby.FirstOrDefault(f => f.Id == Request.Id);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");

                        Entity.Name = Request.Name;
                        Entity.Height = Request.Height;
                        Entity.Weight = Request.Weight;
                        Entity.BirthDate = Request.BirthDate;
                        Entity.MotherId = Request.MotherId;

                        Response = true;

                        Context.SaveChanges();
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public bool Add(BabyModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new MaternityEntities())
                    {

                        var NewBaby = new Models.Entity.Baby
                        {
                            BirthDate = Request.BirthDate,
                            Name = Request.Name,
                            Height = Request.Height,
                            Weight = Request.Weight,
                            MotherId = Request.MotherId
                        };

                        Context.Baby.Add(NewBaby);

                        Context.SaveChanges();

                        Response = true;

                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public List<BabyModel> List()
            {
                var Response = new List<BabyModel>();

                using (var Context = new MaternityEntities())
                {
                    var BabyDoctor = new Baby_Doctor();

                    Response = Context
                                .Baby
                                .Select(s => new BabyModel
                                {
                                    Id = s.Id,
                                    Name = s.Name,
                                    Weight = s.Weight,
                                    Height = s.Height,
                                    BirthDate = s.BirthDate,
                                    MotherId = s.MotherId
                                }).ToList();
                    foreach (var baby in Response)
                    {
                        baby.DoctorList = BabyDoctor.DocsRelatedToBaby(baby.Id);
                    }
                }

                return Response;
            }

            public bool Remove(int BabyId)
            {
                var Response = false;

                try
                {
                    using (var Context = new MaternityEntities())
                    {
                        var Entity = Context.Baby.FirstOrDefault(f => f.Id == BabyId);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");


                        Context.Baby_Doctor.RemoveRange(Context.Baby_Doctor.Where(e => e.BabyId == BabyId));

                        Context.Baby.Remove(Entity);

                        Context.SaveChanges();

                        Response = true;
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }
        }

        public class Mother
        {
            public MotherModel Get(int MotherId)
            {
                var MotherModel = new MotherModel();
                try
                {
                    using (var Context = new MaternityEntities())
                    {
                        var Mother = Context.Mother.FirstOrDefault(f => f.Id == MotherId);

                        if (Mother == null)
                            throw new Exception("Ocorreu um erro ao requisitar os dados de usuário.");

                        MotherModel.Id = Mother.Id;
                        MotherModel.Name = Mother.Name;
                        MotherModel.BirthDate = Mother.BirthDate;
                        MotherModel.Phone = Mother.Phone;
                        MotherModel.StreetName = Mother.StreetName;
                        MotherModel.HouseNumber = Mother.HouseNumber;
                    }

                }
                catch (Exception er)
                {
                    MotherModel.Id = -1;
                }
                return MotherModel;
            }

            public bool Update(MotherModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new MaternityEntities())
                    {
                        var Entity = Context.Mother.FirstOrDefault(f => f.Id == Request.Id);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");

                        Entity.Name = Request.Name;
                        Entity.BirthDate = Request.BirthDate;
                        Entity.Phone = Request.Phone;
                        Entity.StreetName = Request.StreetName;
                        Entity.HouseNumber = Request.HouseNumber;

                        Response = true;

                        Context.SaveChanges();
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public bool Add(MotherModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new MaternityEntities())
                    {

                        var NewMother = new Models.Entity.Mother
                        {
                            BirthDate = Request.BirthDate,
                            Name = Request.Name,
                            Phone = Request.Phone,
                            StreetName = Request.StreetName,
                            HouseNumber = Request.HouseNumber
                        };

                        Context.Mother.Add(NewMother);

                        Context.SaveChanges();

                        Response = true;

                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public List<MotherModel> List()
            {
                var Response = new List<MotherModel>();

                using (var Context = new MaternityEntities())
                {
                    var mother = new Mother();

                    Response = Context
                                .Mother
                                .Select(s => new MotherModel
                                {
                                    Id = s.Id,
                                    Name = s.Name,
                                    Phone = s.Phone,
                                    BirthDate = s.BirthDate,
                                    StreetName = s.StreetName,
                                    HouseNumber = s.HouseNumber
                                }).ToList();

                    foreach (var m in Response)
                    {
                        m.BabyList = mother.FindBabys(m.Id);
                    }
                }

                return Response;
            }

            public bool Remove(int MotherId)
            {
                var Response = false;

                try
                {
                    using (var Context = new MaternityEntities())
                    {
                        var Entity = Context.Mother.FirstOrDefault(f => f.Id == MotherId);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");

                        Context.Mother.Remove(Entity);

                        Context.SaveChanges();

                        Response = true;
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public List<int> FindBabys(int MotherId)
            {
                var Response = new List<int>();

                using (var Context = new MaternityEntities())
                {

                    Response = Context
                                      .Baby
                                      .Where(s => s.MotherId == MotherId)
                                      .Select(s => s.Id).ToList();

                }

                return Response;
            }
        }

        public class Doctor
        {
            public DoctorModel Get(int DoctorId)
            {
                var DoctorModel = new DoctorModel();

                try
                {


                    using (var Context = new MaternityEntities())
                    {
                        var Doctor = Context.Doctor.FirstOrDefault(f => f.Id == DoctorId);

                        if (Doctor == null)
                            throw new Exception("Ocorreu um erro ao requisitar os dados de usuário.");



                        DoctorModel.Id = Doctor.Id;
                        DoctorModel.Crm = Doctor.Crm;
                        DoctorModel.Name = Doctor.Name;
                        DoctorModel.Specialty = Doctor.Specialty;
                        DoctorModel.Phone = Doctor.Phone;

                    }
                }
                catch (Exception er)
                {
                    DoctorModel.Id = -1;
                }

                return DoctorModel;
            }

            public bool Update(DoctorModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new MaternityEntities())
                    {
                        var Entity = Context.Doctor.FirstOrDefault(f => f.Id == Request.Id);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");

                        Entity.Name = Request.Name;
                        Entity.Crm = Request.Crm;
                        Entity.Specialty = Request.Specialty;
                        Entity.Phone = Request.Phone;

                        Response = true;

                        Context.SaveChanges();
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public bool Add(DoctorModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new MaternityEntities())
                    {

                        var NewDoctor = new Models.Entity.Doctor
                        {
                            Crm = Request.Crm,
                            Name = Request.Name,
                            Specialty = Request.Specialty,
                            Phone = Request.Phone
                        };

                        Context.Doctor.Add(NewDoctor);

                        Context.SaveChanges();

                        Response = true;

                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public List<DoctorModel> List()
            {
                var Response = new List<DoctorModel>();

                using (var Context = new MaternityEntities())
                {
                    var BabyDoctor = new Baby_Doctor();

                    Response = Context
                                .Doctor
                                .Select(s => new DoctorModel
                                {
                                    Id = s.Id,
                                    Name = s.Name,
                                    Crm = s.Crm,
                                    Specialty = s.Specialty,
                                    Phone = s.Phone
                                }).ToList();

                    foreach (var doc in Response)
                    {
                        doc.BabysList = BabyDoctor.BabyRelatedToDoc(doc.Id);
                    }
                }

                return Response;
            }

            public bool Remove(int DoctorId)
            {
                var Response = false;

                try
                {
                    using (var Context = new MaternityEntities())
                    {
                        var Entity = Context.Doctor.FirstOrDefault(f => f.Id == DoctorId);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");


                        Context.Baby_Doctor.RemoveRange(Context.Baby_Doctor.Where(e => e.DoctorId == DoctorId));

                        Context.Doctor.Remove(Entity);

                        Context.SaveChanges();

                        Response = true;
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }
        }

        public class Baby_Doctor
        {
            public Baby_DoctorModel Get(int Baby_DoctorId)
            {
                var Baby_DoctorModel = new Baby_DoctorModel();

                try
                {
                    using (var Context = new MaternityEntities())
                    {
                        var Baby_Doctor = Context.Baby_Doctor.FirstOrDefault(f => f.Id == Baby_DoctorId);

                        if (Baby_Doctor == null)
                            throw new Exception("Ocorreu um erro ao requisitar os dados de usuário.");

                        Baby_DoctorModel.Id = Baby_Doctor.Id;
                        Baby_DoctorModel.DoctorId = Baby_Doctor.DoctorId;
                        Baby_DoctorModel.BabyId = Baby_Doctor.BabyId;

                    }
                }
                catch (Exception er)
                {
                    Baby_DoctorModel.Id = -1;
                }


                return Baby_DoctorModel;
            }

            public bool Update(Baby_DoctorModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new MaternityEntities())
                    {
                        var Entity = Context.Baby_Doctor.FirstOrDefault(f => f.Id == Request.Id);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");

                        Entity.DoctorId = Request.DoctorId;
                        Entity.BabyId = Request.BabyId;

                        Response = true;

                        Context.SaveChanges();
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public bool Add(Baby_DoctorModel Request)
            {
                var Response = false;

                try
                {
                    using (var Context = new MaternityEntities())
                    {

                        var NewBaby_Doctor = new Models.Entity.Baby_Doctor
                        {
                            DoctorId = Request.DoctorId,
                            BabyId = Request.BabyId,

                        };

                        Context.Baby_Doctor.Add(NewBaby_Doctor);

                        Context.SaveChanges();

                        Response = true;

                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }

            public List<Baby_DoctorModel> List()
            {
                var Response = new List<Baby_DoctorModel>();

                using (var Context = new MaternityEntities())
                {

                    Response = Context
                                .Baby_Doctor
                                .Select(s => new Baby_DoctorModel
                                {
                                    Id = s.Id,
                                    DoctorId = s.DoctorId,
                                    BabyId = s.BabyId,

                                }).ToList();

                }

                return Response;
            }

            public List<int> DocsRelatedToBaby(int BabyId)
            {
                var Response = new List<int>();

                using (var Context = new MaternityEntities())
                {
                    Response = Context
                                      .Baby_Doctor
                                      .Where(s => s.BabyId == BabyId)
                                      .Select(s => s.DoctorId).ToList();
                }

                return Response;
            }

            public List<int> BabyRelatedToDoc(int DoctorId)
            {
                var Response = new List<int>();

                using (var Context = new MaternityEntities())
                {
                    Response = Context
                                       .Baby_Doctor
                                       .Where(s => s.DoctorId == DoctorId)
                                       .Select(s => s.BabyId).ToList();

                }

                return Response;
            }

            public bool Remove(int Baby_DoctorId)
            {
                var Response = false;

                try
                {
                    using (var Context = new MaternityEntities())
                    {
                        var Entity = Context.Baby_Doctor.FirstOrDefault(f => f.Id == Baby_DoctorId);

                        if (Entity == null)
                            throw new Exception("Ocorreu um erro ao editar os dados do bebe.");

                        Context.Baby_Doctor.Remove(Entity);

                        Context.SaveChanges();

                        Response = true;
                    }
                }
                catch (Exception Ex)
                {
                    Response = false;
                }


                return Response;
            }
        }
    }
}