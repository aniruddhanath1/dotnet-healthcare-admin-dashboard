<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Appointment extends Model
{
    use HasFactory;

    protected $fillable = [
        // Add your fillable fields here, e.g.:
        'patient_id', 'doctor_id', 'scheduled_at', 'status', 'notes'
    ];
}
