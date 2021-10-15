//---------------------------------------------------------------------------------
// Copyright (c) September 2021, devMobile Software
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
//---------------------------------------------------------------------------------
namespace devMobile.IoT.NetCore.Sensirion
{
	using System;
	using System.Threading;
	using System.Device.I2c;

	class Program
	{
		static void Main(string[] args)
		{
			// bus id on the raspberry pi 3
			const int busId = 1;

			I2cConnectionSettings i2cConnectionSettings = new(busId, Sht20.DefaultI2cAddress);

			using I2cDevice i2cDevice = I2cDevice.Create(i2cConnectionSettings);

			using (Sht20 sht20 = new Sht20(i2cDevice))
			{
				while (true)
				{
					double temperature = sht20.Temperature();
					double humidity = sht20.Humidity();

					Console.WriteLine($"{DateTime.Now:HH:mm:ss} Temperature:{temperature:F1}°C Humidity:{humidity:F0}%");

					Thread.Sleep(1000);
				}
			}
		}
	}
}

