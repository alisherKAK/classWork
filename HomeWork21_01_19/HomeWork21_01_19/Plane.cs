using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork21_01_19
{
    class Plane
    {
        private string _model;
        private int _seatsCount;
        private double _engineCapacity;
        private double _width;
        private double _lenth;
        private double _weight;
        private double _velocity;

        public string GetModel() { return _model; }
        public void SetModel(string model) { _model = model; }
        public int GetSeatsCount() { return _seatsCount; }
        public void SetSeatsCount(int seatsCount) { _seatsCount = seatsCount; }
        public double GetEngineCapacity() { return _engineCapacity; }
        public void SetEngineCapacity(double engineCapacity) { _engineCapacity = engineCapacity; }
        public double GetWidth() { return _width; }
        public void SetWidth(double width) { _width = width; }
        public double GetLenth() { return _lenth; }
        public void SetLenth(double lenth) { _lenth = lenth; }
        public double GetWeight() { return _weight; }
        public void SetWeight(double weight) { _weight = weight; }
        public double GetVelocity() { return _velocity; }
        public void SetVelocity(double velocity) { _velocity = velocity; }

        public bool IsMove(ref double velocity)
        {
            if(_velocity > Constants.NULL)
            {
                velocity = _velocity;
                return true;
            }
            velocity = Constants.NULL;
            return false;
        }
    }
    static class Constants
    {
        public static int NULL = 0;
    }
}
