//*********************************************************************
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root
// for license information.
//
// @File: Workloads.cpp
//
// Purpose:
//      <description>
//
// Notes:
//      <special-instructions>
//
//*********************************************************************

#include "stdafx.h"
#include "SmartCacheImpl.h"
#include "Workloads.h"

uint64_t CyclicalWorkload(uint64_t sequenceNumber, SmartCacheImpl<int32_t, int32_t>& smartCache)
{
    // auto start = std::chrono::high_resolution_clock::now();
    for (int32_t i = 1; i < sequenceNumber; i++)
    {
        int32_t* element = smartCache.Get(i);
        if (element == nullptr)
        {
            smartCache.Push(i, i);
        }
    }
    // auto end = std::chrono::high_resolution_clock::now();
    // long elapsed_ns = std::chrono::duration_cast<std::chrono::nanoseconds>(end - start).count();

    // SmartCache::PushLatencyEventMessage msg;
    // msg.ConfigId = smartCache.m_config.ConfigId;
    // msg.PushLatencyNS = elapsed_ns;
    // smartCache.m_config.SendTelemetryMessage(msg);

    return 1;
}
