/**
 * etiqatest.Server
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
import { DayOfWeek } from './dayOfWeek';


export interface DateOnly { 
    year?: number;
    month?: number;
    day?: number;
    dayOfWeek?: DayOfWeek;
    readonly dayOfYear?: number;
    readonly dayNumber?: number;
}
export namespace DateOnly {
}


