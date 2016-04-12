/***************************************************************************
*                                                                          *
* Copyright 2016 Jamie Anderson                                            *
*                                                                          *
* Licensed under the Apache License, Version 2.0 (the "License");          *
* you may not use this file except in compliance with the License.         *
* You may obtain a copy of the License at                                  *
*                                                                          *
*     http://www.apache.org/licenses/LICENSE-2.0                           *
*                                                                          *
* Unless required by applicable law or agreed to in writing, software      *
* distributed under the License is distributed on an "AS IS" BASIS,        *
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. *
* See the License for the specific language governing permissions and      *
* limitations under the License.                                           *
*                                                                          *
***************************************************************************/

using System;
using System.Collections.Concurrent;
using WindowsDeviceManager.Helpers;

namespace WindowsDeviceManager.ValueConverters
{
    public class ValueConverterRegistry<TKey>
    {
        private readonly ConcurrentDictionary<TKey, IValueConverter> _registry;

        public ValueConverterRegistry()
        {
            _registry = new ConcurrentDictionary<TKey, IValueConverter>();
        }

        public IValueConverter GetConverter(TKey key)
        {
            IValueConverter converter;
            if (_registry.TryGetValue(key, out converter))
            {
                return converter;
            }

            return null;
        }

        public bool Register(TKey key, IValueConverter converter, bool overwrite = false)
        {
            var result = _registry.TryAdd(key, converter);

            // If the value could not be added and the overwrite flag is not set, return a registration failure.
            if (!result && !overwrite)
            {
                return false;
            }

            // Keep trying to set the value until there's success.
            while (!result)
            {
                // If the existing value can be retrieved, attempt an update.
                IValueConverter existingConverter;
                if (_registry.TryGetValue(key, out existingConverter))
                {
                    result = _registry.TryUpdate(key, converter, existingConverter);
                }
                // If the value has been removed, attempt an add.
                else
                {
                    result = _registry.TryAdd(key, converter);
                }
            }

            // The registration has succeeded by this point.
            return true;
        }

        public void Register(TKey[] keys, IValueConverter converter, bool overwrite = false)
        {
            keys.ThrowIfNull("keys");

            foreach (var key in keys)
            {
                Register(key, converter, overwrite);
            }
        }

        public void Register(IValueConverter converter, params TKey[] keys)
        {
            converter.ThrowIfNull("converter");
            keys.ThrowIfNull("keys");

            Register(keys, converter, false);
        }
    }
}
