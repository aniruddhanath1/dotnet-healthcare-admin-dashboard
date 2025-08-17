<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\AppointmentController;

// DTO-based endpoints (SQL)
Route::get('appointments/dto', [AppointmentController::class, 'getAllDto']);
Route::get('appointments/dto/{id}', [AppointmentController::class, 'getDto']);
Route::post('appointments/dto', [AppointmentController::class, 'createDto']);
Route::put('appointments/dto/{id}', [AppointmentController::class, 'updateDto']);
Route::delete('appointments/dto/{id}', [AppointmentController::class, 'deleteDto']);

// Model-based (MongoDB) endpoints
Route::get('appointments/mongo', [AppointmentController::class, 'getAllMongo']);
Route::get('appointments/mongo/{id}', [AppointmentController::class, 'getByIdMongo']);
Route::post('appointments/mongo', [AppointmentController::class, 'addMongo']);
Route::put('appointments/mongo/{id}', [AppointmentController::class, 'updateMongo']);
Route::delete('appointments/mongo/{id}', [AppointmentController::class, 'deleteMongo']);
