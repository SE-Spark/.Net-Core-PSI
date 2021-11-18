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
        private BaseRepository<Criminal> criminalRepository;
        private BaseRepository<Foreigner> courseRepository;
        private BaseRepository<Login> loginRepository;
        private BaseRepository<Officer> officerRepository;
        private BaseRepository<Station> stationRepository;
        private BaseRepository<Suspect> suspectRepository;
        private BaseRepository<Work> workRepository;

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
        public BaseRepository<Criminal> CriminalRepository
        {
            get
            {

                if (this.criminalRepository == null)
                {
                    this.criminalRepository = new BaseRepository<Criminal>(Constants.URL_CRIMINAL);
                }
                return criminalRepository;
            }
        }
        public BaseRepository<Foreigner> ForeignerRepository
        {
            get
            {

                if (this.courseRepository == null)
                {
                    this.courseRepository = new BaseRepository<Foreigner>(Constants.URL_FOREIGNER);
                }
                return courseRepository;
            }
        }
        public BaseRepository<Officer> OfficerRepository
        {
            get
            {

                if (this.officerRepository == null)
                {
                    this.officerRepository = new BaseRepository<Officer>(Constants.URL_OFFICER);
                }
                return officerRepository;
            }
        }
        public BaseRepository<Station> StationRepository
        {
            get
            {

                if (this.stationRepository == null)
                {
                    this.stationRepository = new BaseRepository<Station>(Constants.URL_STATION);
                }
                return stationRepository;
            }
        }
        public BaseRepository<Suspect> SuspectRepository
        {
            get
            {

                if (this.suspectRepository == null)
                {
                    this.suspectRepository = new BaseRepository<Suspect>(Constants.URL_SUSPECT);
                }
                return suspectRepository;
            }
        }
        public BaseRepository<Work> WorkRepository
        {
            get
            {

                if (this.workRepository == null)
                {
                    this.workRepository = new BaseRepository<Work>(Constants.URL_WORK);
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
