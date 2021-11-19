using PSI_NET_CORE.Models;
using PSI_NET_CORE.Network.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_NET_CORE.Network.Repo
{
    public class UnitOfWork
    {
        private BaseRepository<CitizenDto> citizenRepository;
        private BaseRepository<CriminalDto> criminalRepository;
        private BaseRepository<ForeignerDto> courseRepository;
        private BaseRepository<Login> loginRepository;
        private BaseRepository<OfficerDto> officerRepository;
        private BaseRepository<StationDto> stationRepository;
        private BaseRepository<SuspectDto> suspectRepository;
        private BaseRepository<WorkDto> workRepository;

        public BaseRepository<CitizenDto> CitizenRepository
        {
            get
            {
                if (this.citizenRepository == null)
                {
                    this.citizenRepository =new BaseRepository<CitizenDto>(Constants.URL_CITIZEN);
                }
                return citizenRepository;
            }
        }
        public BaseRepository<CriminalDto> CriminalRepository
        {
            get
            {

                if (this.criminalRepository == null)
                {
                    this.criminalRepository = new BaseRepository<CriminalDto>(Constants.URL_CRIMINAL);
                }
                return criminalRepository;
            }
        }
        public BaseRepository<ForeignerDto> ForeignerRepository
        {
            get
            {

                if (this.courseRepository == null)
                {
                    this.courseRepository = new BaseRepository<ForeignerDto>(Constants.URL_FOREIGNER);
                }
                return courseRepository;
            }
        }
        public BaseRepository<OfficerDto> OfficerRepository
        {
            get
            {

                if (this.officerRepository == null)
                {
                    this.officerRepository = new BaseRepository<OfficerDto>(Constants.URL_OFFICER);
                }
                return officerRepository;
            }
        }
        public BaseRepository<StationDto> StationRepository
        {
            get
            {

                if (this.stationRepository == null)
                {
                    this.stationRepository = new BaseRepository<StationDto>(Constants.URL_STATION);
                }
                return stationRepository;
            }
        }
        public BaseRepository<SuspectDto> SuspectRepository
        {
            get
            {

                if (this.suspectRepository == null)
                {
                    this.suspectRepository = new BaseRepository<SuspectDto>(Constants.URL_SUSPECT);
                }
                return suspectRepository;
            }
        }
        public BaseRepository<WorkDto> WorkRepository
        {
            get
            {

                if (this.workRepository == null)
                {
                    this.workRepository = new BaseRepository<WorkDto>(Constants.URL_WORK);
                }
                return workRepository;
            }
        }


        public BaseRepository<Login> LoginRepository
        {
            get
            {

                if (this.citizenRepository == null)
                {
                    this.loginRepository = new BaseRepository<Login>(Constants.URL_WORK);
                }
                return loginRepository;
            }
        }
    }
}
