﻿// Concept Matrix 3.
// Licensed under the MIT license.

namespace Anamnesis
{
	using System.Threading.Tasks;

	public interface IServices
	{
		T Get<T>()
			where T : IService;

		Task Add<T>()
			where T : IService, new();
	}
}