<?php

namespace App\Models\Mongo;

use Jenssegers\Mongodb\Eloquent\Model as Eloquent;

class Appointment extends Eloquent
{
    protected $connection = 'mongodb';
    protected $collection = 'appointments';

    protected $fillable = [
        // Add your fillable fields here, e.g.:
        'patient_id', 'doctor_id', 'scheduled_at', 'status', 'notes'
    ];
}
