using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dac;

namespace PlanningSystem.Data
{
    public class Poappservice
    {
        private readonly POAPP001Context _context;



        public Poappservice(POAPP001Context context)
        {
            _context = context;

        }
        public Task<List<PlanHead>> GetPlanHeadAsync()
        {
            List<PlanHead> colPlanHeadResult =
                 new List<PlanHead>();
            colPlanHeadResult =
                (from assessresult in _context.PlanHead
                 select assessresult).ToList();


            return Task.FromResult(colPlanHeadResult);

        }

        public Task<TierPlanDetail> CreateTierDetailAsync(TierPlanDetail tier)
        {
            _context.TierPlanDetail.Add(tier);
            _context.SaveChanges();

            return Task.FromResult(tier);
        }
        public Task<PlanHead> CreatePlanHeadAsync(PlanHead objPlanHead)
        {
            _context.PlanHead.Add(objPlanHead);
            //create detail
            _context.SaveChanges();

            return Task.FromResult(objPlanHead);
        }
        public List<Dac.StatsSummary> ExecuteSimulAsync(AccessmentSimulation objSimul)
        {
            spdata spdata = new spdata();
            List<Dac.StatsSummary> stats;

            stats = spdata.ExecuteSimnulation(objSimul.Simulationid, (long)objSimul.Planid, (long)objSimul.Tierplanid, 0);

            return stats;
        }
        public List<Dac.StatsSummary> CreateSimulAsync(AccessmentSimulation objSimul)
        {
            spdata spdata = new spdata();
            List<Dac.StatsSummary> stats;
            _context.AccessmentSimulation.Add(objSimul);
            _context.SaveChanges();


            stats = spdata.ExecuteSimnulation(objSimul.Simulationid, (long)objSimul.Planid, (long)objSimul.Tierplanid, 0);

            return stats;
        }
        public Task<List<AccessmentSimulation>> GetSimulAsync()
        {
            List<AccessmentSimulation> colSimulResult =
                 new List<AccessmentSimulation>();
            colSimulResult =
                (from assessresult in _context.AccessmentSimulation
                 select assessresult).ToList();


            return Task.FromResult(colSimulResult);

        }
        public int ExecuteSimulAsync(long i, long a, long b, long c)
        {
            spdata spdata = new spdata();
            int results = spdata.ConfirmANDSave((int)i, (int)a, (int)b, (int)c);

            //}
            return 1;

        }
        public int ApplyCreditrule(int i)
        {
            spdata spdata = new spdata();

            spdata.ApplyCreditRule(i);
            return 1;
        }
        public int ConfirmCredit(int i)
        {
            spdata spdata = new spdata();

            spdata.ConfirmCredit(i);
            return 1;
        }
        public int DeletePreviousSimulation(AccessmentSimulation A)
        {
            spdata spdata = new spdata();
            int results = spdata.DeleteSimulandResult(A.Simulationid);

            //}
            return results;

        }
        public Task<List<CustAssessResultTable>> GetSimulAsync(int i, long teamid)
        {
            List<CustAssessResultTable> colSimulResult =
                 new List<CustAssessResultTable>();
            colSimulResult =
                (from assessresult in _context.CustAssessResultTable
                 where assessresult.SalesTeamId == teamid
                  && assessresult.Resultid == i
                 select assessresult).ToList();


            return Task.FromResult(colSimulResult);

        }
        public Task<List<AccessmentSimulation>> GetSimulAsync(object value)
        {
            List<AccessmentSimulation> colSimulResult =
                 new List<AccessmentSimulation>();
            colSimulResult =
                (from assessresult in _context.AccessmentSimulation
                 where assessresult.Simulationid == System.Convert.ToInt32(value.ToString())
                 select assessresult).ToList();


            return Task.FromResult(colSimulResult);

        }
        public Task<TierPlanHead> CreateTierPlanHeadAsync(TierPlanHead objTierPlanHead)
        {
            _context.TierPlanHead.Add(objTierPlanHead);
            _context.SaveChanges();
            return Task.FromResult(objTierPlanHead);
        }
        public Task<PlanDetail> CreatePlanDetail(PlanDetail objplandetail)
        {
            _context.PlanDetail.Add(objplandetail);
            _context.SaveChanges();
            return Task.FromResult(objplandetail);
        }
        public void CreatePlanDetailAsync(PlanHead objPlanHead)
        {

            spdata spdata = new spdata();
            spdata.spdataexec(objPlanHead.Planid, 1);


        }

        public List<Dac.StatsSummary> GetSummary(int i)
        {
            spdata spdata = new spdata();

            List<Dac.StatsSummary> stats = new List<Dac.StatsSummary>();
            stats = spdata.spsimulsummary(i);
            return stats;
        }
        public List<Dac.AccountResult> GetACCTResult(int i)
        {
            spdata spdata = new spdata();

            List<Dac.AccountResult> stats = new List<Dac.AccountResult>();
            stats = spdata.getAccountresults(i);

            return stats;
        }
        
        public void CreateTierPlanDetailAsync(TierPlanHead objTierPlanHead)
        {
            spdata spdata = new spdata();
            spdata.spdatatierexec(objTierPlanHead.Tierplanid, objTierPlanHead.Tiercount);
        }
        public Task<List<PlanHead>> GetPlanAsync(long planid)
        {
            List<PlanHead> colPlanHeadResult =
                 new List<PlanHead>();
            colPlanHeadResult =
                (from assessresult in _context.PlanHead
                 where assessresult.Planid == planid
                 select assessresult).ToList();
            return Task.FromResult(colPlanHeadResult);

        }
        public Task<List<PlanDetail>> GetPlanDetailAsync(long planid)
        {
            List<PlanDetail> colPlanDetailResult =
                 new List<PlanDetail>();
            colPlanDetailResult =
                (from assessresult in _context.PlanDetail
                 where assessresult.PlanHeadid == planid
                 select assessresult).ToList();
            return Task.FromResult(colPlanDetailResult);

        }
        public Task<List<TierPlanDetail>> GetTierPlanDetailAsync(long tierplanid)
        {
            List<TierPlanDetail> colPlanDetailResult =
                 new List<TierPlanDetail>();
            colPlanDetailResult =
                (from assessresult in _context.TierPlanDetail
                 where assessresult.Tierplanid == tierplanid
                 select assessresult).ToList();
            return Task.FromResult(colPlanDetailResult);
        }
        public Task<List<TierPlanHead>> GetTierPlanHeadAsync(long tierplanid)
        {
            List<TierPlanHead> colPlanDetailResult =
                 new List<TierPlanHead>();
            colPlanDetailResult =
                (from assessresult in _context.TierPlanHead
                 where assessresult.Tierplanid == tierplanid
                 select assessresult).ToList();
            return Task.FromResult(colPlanDetailResult);
        }
        public Task<List<TierPlanHead>> GetTierPlanHeadAsync()
        {
            List<TierPlanHead> colPlanDetailResult =
                 new List<TierPlanHead>();
            colPlanDetailResult =
                (from assessresult in _context.TierPlanHead
                 select assessresult).ToList();
            return Task.FromResult(colPlanDetailResult);
        }

     

    }

}
